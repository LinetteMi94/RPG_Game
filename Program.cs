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
        Hero hero = ChooseHero(name);
        hero.OnLevelUp += ShowLevelUpMessage;
        hero.DisplayCharacterStats();

        Monster[] monsters = [new ForestTroll(), new BurningElemental(),new Zombie()];
        var battle = new Battle();
        battle.OnMonsterDefeated += monster =>
        {
            hero.GetScore(monster.ExpReward);
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

        if (hero.IsAlive) Console.WriteLine($"{hero.Name} выжил в этой страшной битве! Заработаны очки опыта: {hero.Score} и золотые монеты: {hero.Money}");
        else Console.WriteLine($"Увы... {hero.Name} не выжил в этой битве");
    }

    private static void ShowLevelUpMessage(Hero obj)
    {
        Console.WriteLine($"{obj.Name} получил {obj.Level} уровень!");
    }

    private static Hero ChooseHero(string heroName)
    {
        Console.WriteLine("Выберите класс героя:");
        Console.WriteLine("1. Друид\t2. Охотник\t3. Маг\t4. Паладин\t5. Жрец\t6. Разбойник\t7. Шаман\t8. Чернокнижник\t9. Воин");
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