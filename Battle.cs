using RPG_Game.Characters.Heroes;
using RPG_Game.Characters.Monsters;
using RPG_Game.Interfaces;

namespace RPG_Game;

/// <summary>
/// Класс, отвечающий за проведение боя между героем и монстром.
/// Выполняет атаки участников и определяет победителя.
/// </summary>
public class Battle
{
    public event Action<Monster>? OnMonsterDefeated;
    public void Start(Hero hero, Monster monster)
    {
        Console.WriteLine("Начинается бой!");
        Console.WriteLine($"{hero.Name} против {monster.Name}");
        while (true)
        {
            Console.WriteLine("Нажмите любую клавишу для атаки");
            Console.ReadLine();
            hero.Attack(monster);
            if (!monster.IsAlive)
            {
                Console.WriteLine($"{monster.Name} повержен!\t {hero.Name} победил!");
                OnMonsterDefeated?.Invoke(monster);
                break;
            }
            Console.WriteLine();
            monster.Attack(hero);
            if (!hero.IsAlive)
            {
                Console.WriteLine($"{hero.Name} повержен!\t {monster.Name} победил!");
                break;
            }
            
            if (hero is IHealer<Hero> healer && new Random().Next(100) < 40)
            {
                healer.Heal();
                Console.WriteLine($"{hero.Name}, здоровье {hero.Health}/{hero.MaxHealth}!");
            }
        }
    }
}