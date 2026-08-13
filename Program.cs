using RPG_Game.Characters.Heroes;
using RPG_Game.Characters.Monsters;
using RPG_Game.Characters;

namespace RPG_Game;

internal static class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите имя героя: ");
        var name = Console.ReadLine();

        Console.WriteLine("Выберите класс героя:");
        Console.WriteLine("1. Друид\t2. Охотник\t3. Маг\t4. Паладин\t5. Жрец\t6. Разбойник\t7. Шаман\t8. Чернокнижник\t9. Воин");
        var choice = int.Parse(Console.ReadLine());

        Hero hero = null;
        switch (choice)
        {
            case 1:
                hero = new Druid(name);
                break;
            case 2:
                hero = new Hunter(name);
                break;
            case 3:
                hero = new Mage(name);
                break;
            case 4:
                hero = new Paladin(name);
                break;
            case 5:
                hero = new Priest(name);
                break;
            case 6:
                hero = new Rogue(name);
                break;
            case 7:
                hero = new Shaman(name);
                break;
            case 8:
                hero = new Warlock(name);
                break;
            case 9:
                hero = new Warrior(name);
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                return;
        }

        hero.DisplayCharacterStats();

        Monster lion = new Monster("Лев", 200, 40, 23);
        Console.WriteLine($"Из чащобы выходит {lion.Name} (Здоровье: {lion.Health}, Броня: {lion.Armor})");

        Character champeon = null;
        while (true)
        {
            Console.WriteLine($"Нажмите Enter, чтобы атаковать {lion.Name}...");
            Console.ReadLine();
            hero.Attack(lion);
            lion.DisplayCharacterStats();
            Console.WriteLine($"{hero.Name} наносит {hero.Damage} урона {lion.Name}");
            if (!lion.IsAlive)
            {
                champeon = hero;
                Console.WriteLine($"{lion.Name} повержен!");
                break;
            }
            lion.Attack(hero);
            Console.WriteLine($"{lion.Name} наносит {lion.Damage} урона {hero.Name}");
            if (!hero.IsAlive)
            {
                champeon = lion;
                Console.WriteLine($"{hero.Name} повержен!");
                break;
            }
            hero.DisplayCharacterStats();
        }
        Console.WriteLine($"{champeon.Name} победил!");
    }
}