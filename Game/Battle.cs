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
    private static bool _isRunning = true;
    public void Start(Hero hero, Monster monster)
    {
        _hero = hero;
        _monster = monster;
        Console.WriteLine("Начинается бой!");
        Console.WriteLine($"{_hero.Name} против {_monster.Name}");
        while (_isRunning)
        {
            Console.WriteLine("Нажмите любую клавишу для атаки");
            Console.ReadKey();
            hero.ShowBattleMenu(_monster, HandleBattleChoice);
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
                if (!IsStartBattleForDifferentClasses()) _hero.ShowBattleMenu(_monster, HandleBattleChoice);
                break;
            case 2:
                Console.WriteLine("Выпить зелье");
                break;
            case 3:
                if (new Random().Next(100) < 50)
                {
                    Console.WriteLine("Вам удалось сбежать!");
                    _isRunning = false;
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

    private static bool IsStartBattleForDifferentClasses()
    {
        if (_hero is Astromancer) return AttackMenu.ShowAstromancerAttackMenu(_monster, _hero.ShowAbilities);
        if (_hero is Druid) return AttackMenu.ShowDruidAttackMenu(_monster, _hero.ShowAbilities);
        if (_hero is Mage) return AttackMenu.ShowMageAttackMenu(_monster, _hero.ShowAbilities);
        if (_hero is Minstrel) return AttackMenu.ShowMinstrelAttackMenu(_monster, _hero.ShowAbilities);
        if (_hero is Pirate) return AttackMenu.ShowPirateAttackMenu(_monster, _hero.ShowAbilities);
        if (_hero is Ranger) return AttackMenu.ShowRangerAttackMenu(_monster, _hero.ShowAbilities);
        if (_hero is Shaman) return AttackMenu.ShowShamanAttackMenu(_monster, _hero.ShowAbilities);
        if (_hero is Warlock) return AttackMenu.ShowWarlockAttackMenu(_monster, _hero.ShowAbilities);
        return AttackMenu.ShowWarriorAttackMenu(_monster, _hero.ShowAbilities);
    }
}