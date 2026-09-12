using System;
using RPG_Game.Characters.Heroes;
using RPG_Game.Characters.Monsters;
using RPG_Game.Interfaces;

namespace RPG_Game.Game;

/// <summary>
/// Класс, отвечающий за проведение боя между героем и монстром.
/// Выполняет атаки участников и определяет победителя.
/// </summary>
public class Battle
{
    public event Action<Monster>? OnMonsterDefeated;
    private static Hero? _hero;
    private static Monster? _monster;
    private static bool _isBattleRunning = true;
    private static bool _isRoundRunning;
    public void Start(Hero hero, Monster monster)
    {
        _hero = hero;
        _monster = monster;
        Console.WriteLine("Начинается бой!");
        Console.WriteLine($"{_hero.Name} против {_monster.Name}");
        while (_isBattleRunning)
        {
            Console.WriteLine("Нажмите любую клавишу для атаки");
            Console.ReadKey();
            _isRoundRunning = true;
            while(_isRoundRunning) hero.ShowBattleMenu(_monster, HandleBattleChoice);
            if (!_monster.IsAlive)
            {
                Console.WriteLine($"{_monster.Name} повержен!\t {_hero.Name} победил!");
                OnMonsterDefeated?.Invoke(_monster);
                break;
            }
            Console.WriteLine();
            _monster.Attack(_hero);
            if (!hero.IsAlive)
            {
                Console.WriteLine($"{_hero.Name} повержен!\t {_monster.Name} победил!");
                break;
            }
        }
    }
    
    /// <summary>
    /// Обрабатывает выбор игрока во время битвы
    /// и запускает соответствующее действие.
    /// </summary>
    private static void HandleBattleChoice(int choice)
    {
        switch (choice)
        {
            case 1:
                var spellIndex = _hero.ShowAttackMenu(_monster)-1;
                if (spellIndex >= 0)
                {
                    var spellForAttack = _hero.LearnedSpells[spellIndex];
                    _hero.Attack(_monster, spellForAttack);
                    _isRoundRunning = false;
                    Console.WriteLine("Нажми любую клавишу для продолжения...");
                    Console.ReadKey();
                }
                break;
            case 2:
                Console.WriteLine("Выпить зелье");
                break;
            case 3:
                if (new Random().Next(100) < 50)
                {
                    Console.WriteLine("Вам удалось сбежать!");
                    _isBattleRunning = false;
                }
                else Console.WriteLine("Вы попытались сбежать, но ничего не вышло!");
                break;
            case 4:
                Console.WriteLine($"{_hero!.Name} стоит и ничего не делает...");
                break;
            case 5:
                if (_hero is IHealer healer) healer.Heal();
                Console.WriteLine($"{_hero!.Name}, здоровье {_hero.Health}/{_hero.MaxHealth}!");
                break;
        }
    }
}