using RPG_Game.Characters.Heroes;
using RPG_Game.Characters.Monsters;
using RPG_Game.Characters;

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

        Monster[] monsters = [new ForestTroll(), new BurningElemental(),new Zombie()];
        var battle = new Battle();
        battle.OnMonsterDefeated += monster =>
        {
            hero.Level.AddExperience(monster.ExpReward);
        };
        battle.OnMonsterDefeated += monster =>
        {
            hero.GetMoney(monster.GoldReward);
        };
        foreach (var monster in monsters)
        {
            if (!hero.IsAlive) break;
            battle.Start(hero, monster);
        }
    }

    private static Hero ChooseHero(string heroName)
    {
        Console.WriteLine("Выберите класс героя:");
        Console.WriteLine("1. Друид  2. Охотник  3. Маг  4. Паладин  5. Жрец  6. Разбойник  7. Шаман  8. Чернокнижник  9. Воин");
        var choice = int.Parse(Console.ReadLine());
        
        if (choice == 1) return new Druid(heroName);
        if (choice == 2) return new Hunter(heroName);
        if (choice == 3) return new Mage(heroName);
        if (choice == 4) return new Paladin(heroName);
        if (choice == 5) return new Priest(heroName);
        if (choice == 6) return new Rogue(heroName);
        if (choice == 7) return new Shaman(heroName);
        if (choice == 8) return new Warlock(heroName);
        if (choice == 9) return new Warrior(heroName);
        Console.WriteLine("Неверный выбор. Будет выбран класс по умолчанию");
        return new Rogue(heroName);
    }
}