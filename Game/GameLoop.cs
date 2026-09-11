using System;
using System.Threading;
using RPG_Game.Characters.Heroes;
using RPG_Game.Input;
using RPG_Game.World;

namespace RPG_Game.Game;

/// <summary>
/// Управляет основным игровым процессом.
/// Отвечает за запуск игры, взаимодействие игрока с меню
/// и последовательность выполнения игровых действий.
/// </summary>
public static class GameLoop
{
    private static Hero _hero;
    private static bool _isRunning;

    public static void Start()
    {
        _isRunning = true;
        _hero = CreatePlayer();
        while (_isRunning)
        {
            _hero.ShowMainMenu(HandleChoice);
            if (!_hero.IsAlive) GameOver();
        }
    }
    
    /// <summary>
    /// Создаёт нового персонажа игрока.
    /// Определяет выбранный класс героя и возвращает соответствующий объект.
    /// </summary>
    private static Hero CreatePlayer()
    {
        Console.Write("Введите имя героя: ");
        var heroName = Console.ReadLine();
        Console.WriteLine("Выберите класс героя:");
        var classes = "1. Друид  2. Следопыт  3. Маг  4. Менестрель  5. Астромант  6. Пират  7. Шаман  8. Колдун  9. Воин";
        var choice = classes.GetValidInput(9);
        switch (choice)
        {
            case 1:
                return new Druid(heroName);
            case 2:
                return new Ranger(heroName);
            case 3:
                return new Mage(heroName);
            case 4:
                return new Minstrel(heroName);
            case 5:
                return new Astromancer(heroName);
            case 6:
                return new Pirate(heroName);
            case 7:
                return new Shaman(heroName);
            case 8:
                return new Warlock(heroName);
            default: 
                return new Warrior(heroName);
        }
    }
    
    /// <summary>
    /// Обрабатывает выбор игрока из главного меню
    /// и запускает соответствующее действие.
    /// </summary>
    private static void HandleChoice(string choice)
    {
        switch (choice)
        {
            case "1":
                _hero.DisplayCharacterStats();
                break;
            case "2":
                _hero.ShowInventoryMenu();
                break;
            case "3":
                _hero.HaveRest();
                break;
            case "4":
                var random =  new Random();
                _hero.StartRandomEncounter(random.Next(1, 4));
                break;
            case "5":
                _isRunning = false;
                break;
        }
    }

    private static void GameOver()
    {
        Console.Clear();
        Console.WriteLine("💀 GAME OVER 💀");
        Console.WriteLine();
        Console.WriteLine($"{_hero.Name} погиб...");
        Console.WriteLine();
        Console.WriteLine("Спасибо за игру!");
        _isRunning = false;
    }
}