using System;
using System.Collections.Generic;
using System.Threading;
using RPG_Game.Characters.Monsters;
using RPG_Game.Characters.Heroes;
using RPG_Game.Game;
using RPG_Game.Items;
using RPG_Game.Messages;

namespace RPG_Game.World;

/// <summary>
/// Управляет случайными приключениями и встречами игрока.
/// Определяет случайное событие и запускает соответствующее приключение.
/// </summary>
public static class EncounterSystem
{
    private static Hero _hero;
    private static readonly List<Item> _travelItems =
    [
    new("Кривой рог",
        "Небольшой рог единорога.",
        20),

    new("Старая монета",
        "Потёртая монета неизвестного происхождения.",
        10),

    new("Странный камень",
        "Гладкий камень необычного цвета. Выглядит совершенно бесполезно.",
        5),

    new("Перо ворона",
        "Большое чёрное перо.",
        7),

    new("Клык зверя",
        "Острый клык неизвестного хищника.",
        12),

    new("Пучок трав",
        "Свежие травы, собранные на лесной тропе.",
        8),

    new("Старая карта",
        "Потрёпанная карта с непонятными отметками.",
        18),

    new("Ржавый ключ",
        "Старый ключ неизвестного назначения.",
        10),

    new(
        "Кусок янтаря",
        "Небольшой кусочек янтаря.",
        25),

    new("Кроличья лапка",
        "Старая кроличья лапка. Говорят, приносит удачу.",
        6),

    new("Зуб гоблина",
        "Небольшой кривой зуб.",
        5),

    new("Осколок кристалла",
        "Маленький полупрозрачный осколок.",
        30),

    new("Старая фляга",
        "Потрёпанная металлическая фляга.",
        12),

    new("Перо совы",
        "Мягкое серое перо.",
        6),

    new("Неизвестный амулет",
        "Небольшой амулет с непонятным символом.",
        25),

    new("Костяная пуговица",
        "Старая пуговица из кости.",
        3),

    new("Красивый камень",
        "Небольшой гладкий камень необычной формы.",
        4),

    new("Сломанный медальон",
        "Старый медальон с повреждённой застёжкой.",
        20),

    new("Сухой гриб",
        "Странный гриб, который выглядит совершенно обычным.",
        3),

    new("Старая ложка",
        "Потёртая металлическая ложка.",
        5),

    new("Порванный мешочек",
        "Старый мешочек, найденный на дороге.",
        7),

    new("Кусок ткани",
        "Небольшой кусок плотной ткани.",
        4),

    new("Птичье яйцо",
        "Небольшое яйцо, найденное в траве.",
        8),

    new("Старая пряжка",
        "Потёртая металлическая пряжка.",
        9),

    new("Осколок стекла",
        "Небольшой кусок цветного стекла.",
        5)
];
    
    /// <summary>
    /// Создаёт случайного монстра для встречи с героем.
    /// Уровень монстра определяется на основе уровня героя.
    /// </summary>
    /// <param name="heroLevel">Текущий уровень героя.</param>
    /// <returns>Случайно выбранный монстр.</returns>
    private static Monster GetRandomMonster(int heroLevel)
    {
        int monsterLevel = Math.Max(1, heroLevel + new Random().Next(-2, 3));
        var choice = new Random().Next(100);
        return choice switch
        {
            < 35 => new Rat(monsterLevel),
            < 55 => new Zombie(monsterLevel),
            < 70 => new ForestTroll(monsterLevel),
            < 90 => new Goblin(monsterLevel),
            < 95 => new Leprechaun(monsterLevel),
            _ => new BurningElemental(monsterLevel),
        };
    }

    
    /// <summary>
    /// Создаёт нападение случайного монстра на героя
    /// </summary>
    private static void MonsterEncounter()
    {
        var monster = GetRandomMonster(_hero.Level.Level);
        Console.WriteLine($"Вам повстречался на пути {monster.Name}, {monster.Level} уровень");
        var battle = new Battle();
        battle.OnMonsterDefeated += monster =>
        {
            _hero.Level.AddExperience(monster.ExpReward);
            _hero.AddMoney(monster.GoldReward);
            _hero.TakeLoot(monster);
        };
        battle.Start(_hero, monster);
    }

    /// <summary>
    /// Выбирает случайное приключения для героя
    /// </summary>
    public static void StartRandomEncounter(this Hero hero, int adventureNumber)
    {
        _hero = hero;
        var choice = new Random().Next(100);
        switch (adventureNumber)
        {
            case 1:
                MonsterEncounter();
                break;
            case 2:
                BadEncounter(choice);
                break;
            case 3:
                GoodEncounter(choice);
                break;
            case 4:
                NeutralEncounter();
                break;
        }
    }
    
    private static void BadEncounter(int choice)
    {
        switch (choice)
        {
            case < 33:
                AdventureMessages.ShowGoldLossMessage();
                var gold = new Random().Next(2, 13);
                if (_hero.Money<gold) gold = _hero.Money;
                _hero.RemoveMoney(gold);
                Console.WriteLine(" - " + gold + " золотых!");
                break;
            case < 66: //игрок теряет немного здоровья и теряет сознание
                AdventureMessages.ShowKnockOutMessage();
                var health1 = _hero.MaxHealth/10;
                var lessHealth1 = new Random().Next(health1/2,health1*2);
                if (lessHealth1 > _hero.Health) lessHealth1 = _hero.Health-1;
                _hero.TakeDamage(lessHealth1, true);
                Console.WriteLine(" - " + lessHealth1 + " здоровья!");
                Console.WriteLine("Потеря сознания будет длиться 10 секунд!");
                Thread.Sleep(10000);
                AdventureMessages.ShowAwakeMessage();
                break;
            case < 100: //игрок теряет здоровье. Если здоровья остаётся 1, то он теряет сознание
                AdventureMessages.ShowDamageMessage();
                var health2 = _hero.MaxHealth/10;
                var lessHealth2 = new Random().Next(health2/3,health2*3);
                if (lessHealth2 > _hero.Health)
                {
                    lessHealth2 = _hero.Health-1;
                    AdventureMessages.ShowKnockOutMessage();
                    Console.WriteLine("Потеря сознания будет длиться 15 секунд!");
                    Thread.Sleep(15000);
                    AdventureMessages.ShowAwakeMessage();
                }
                _hero.TakeDamage(lessHealth2, true);
                Console.WriteLine(" - " + lessHealth2 + " здоровья!");
                break;
        }
    }
    private static void GoodEncounter(int choice)
    {
        switch (choice)
        {
            case < 33:
                AdventureMessages.ShowHealMessage();
                var health = _hero.MaxHealth/10;
                var healthForRestore = new Random().Next(health/2,health*2);
                var needHealth = _hero.MaxHealth - _hero.Health;
                if (needHealth < healthForRestore) healthForRestore = needHealth;
                if (healthForRestore != 0)
                {
                    Console.WriteLine(" + " + healthForRestore + " здоровья!");
                    _hero.RestoreHealth(healthForRestore);
                }
                break;
            case < 66:
                AdventureMessages.ShowItemMessage();
                Item item = _travelItems[new Random().Next(_travelItems.Count)];
                _hero.AddItem(item);
                break;
            case < 100:
                AdventureMessages.ShowGoldFoundMessage();
                var gold = new Random().Next(2, 13);
                _hero.AddMoney(gold);
                Console.WriteLine(" +  " + gold + " золотых!");
                break;
        }
    }
    private static void NeutralEncounter() => AdventureMessages.ShowTravelMessage();
}