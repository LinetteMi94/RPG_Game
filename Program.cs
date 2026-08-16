using RPG_Game.Characters.Heroes;
using RPG_Game.Characters.Monsters;

namespace RPG_Game;

internal static class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Введите имя героя: ");
        var name = Console.ReadLine();
        Hero hero = ChooseHero(name);
        hero.DisplayCharacterStats();

        Monster[] monsters = [new BurningElemental(), new ForestTroll(), new Zombie(), new Zombie(), new Rat(), new Goblin(), new Zombie(), new Zombie(), new Zombie()];
        var battle = new Battle();
        battle.OnMonsterDefeated += monster =>
        {
            hero.Level.AddExperience(monster.ExpReward);
            hero.GetMoney(monster.GoldReward);
            hero.TakeLoot(monster);
        };
        foreach (var monster in monsters)
        {
            if (!hero.IsAlive) break;
            battle.Start(hero, monster);
            hero.ShowInventory();
        }
    }

    private static Hero ChooseHero(string heroName)
    {
        Console.WriteLine("Выберите класс героя:");
        Console.WriteLine("1. Друид  2. Охотник  3. Маг  4. Паладин  5. Жрец  6. Разбойник  7. Шаман  8. Чернокнижник  9. Воин");
        var choice = int.Parse(Console.ReadLine());
        if (choice < 1 || choice > 9)
        {
            Console.WriteLine("Неверный выбор. Будет выбран случайный класс");
            choice = new Random().Next(1,10);
        }
        switch (choice)
        {
            case 1:
                return new Druid(heroName);
            case 2:
                return new Hunter(heroName);
            case 3:
                return new Mage(heroName);
            case 4:
                return new Paladin(heroName);
            case 5:
                return new Priest(heroName);
            case 6:
                return new Rogue(heroName);
            case 7:
                return new Shaman(heroName);
            case 8:
                return new Warlock(heroName);
            case 9:
                return new Warrior(heroName);
            default:
                return null;
        }
    }
}