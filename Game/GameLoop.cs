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
    private static bool _isCityActive;

    /// <summary>
    /// Создаёт нового персонажа игрока.
    /// Определяет выбранный класс героя и возвращает соответствующий объект.
    /// </summary>
    private static Hero CreatePlayer()
    {
        Console.Write("Введите имя героя: ");
        var heroName = Console.ReadLine();
        Console.WriteLine("Выберите класс героя:");
        Console.WriteLine("1. Друид  2. Следопыт  3. Маг  4. Менестрель  5. Астромант  6. Пират  7. Шаман  8. Колдун  9. Воин  10. Циркач");
        var choice = InputValidator.GetValidInput(10);
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
            case 9:
                return new Warrior(heroName);
            default: 
                return new Trickster(heroName);
        }
    }
    
    public static void Start()
    {
        _isRunning = true;
        _hero = CreatePlayer();
        while (_isRunning)
        {
            _hero.ShowMainMenu(HandleMainMenuChoice);
            Console.WriteLine("Нажми любую клавишу для продолжения...");
            Console.ReadKey();
            if (!_hero.IsAlive) GameOver();
        }
    }
    
    /// <summary>
    /// Обрабатывает выбор игрока из меню города
    /// и запускает соответствующее действие.
    /// </summary>
    private static void HandleTownMenuChoice(int choice)
    {
        _hero.RestorationOfInitialResourceAndHealth();
        switch (choice)
        {
            case 1:
                // Посетить таверну
                Console.WriteLine("Вы посетили таверну");
                break;
            case 2:
                // Пойти к аптекарю
                Console.WriteLine("Вы пошли к аптекарю");
                break;
            case 3:
                // Найти старьёвщика
                Console.WriteLine("Вы нашли старьёвщика");
                break;
            case 4:
                // Прогуляться
                Console.WriteLine("Вы прогуливаетесь по городу");
                break;
            case 5:
                VisitMentor();
                break;
            case 6:
                Console.WriteLine($"{_hero.Name} выходит из города");
                _isCityActive = false;
                break;
        }
        Console.WriteLine("Нажми любую клавишу для продолжения...");
        Console.ReadKey();
    }

    /// <summary>
    /// Позволяет герою посетить наставника, просмотреть доступные неизученные заклинания и изучить выбранное.
    /// </summary>
    private static void VisitMentor()
    {
        Console.Clear();
        Console.WriteLine("📚 Ты входишь в дом наставника.\n");
        Console.WriteLine("Наставник: Добро пожаловать.");
        Console.WriteLine("📚 Наставник внимательно смотрит на тебя.");
        var spells = _hero.SpellsToLearn.Where(x => x.NeedLevel <= _hero.Level.Level).ToList();
        if (!spells.Any())
        {
            Console.WriteLine("Наставник: Я пока не могу научить тебя ничему новому.\n");
            return;
        } 
        Console.WriteLine("Наставник: Я могу обучить тебя новому заклинанию.\n");
        _hero.ShowSpells(spells, true);
        Console.WriteLine("\nВыбери заклинание для изучения (0 - выход в город)");
        var choice = InputValidator.GetValidInput(spells.Count, 0);
        if (choice <= 0) return;
        var spell = spells.Where((x,i) => i==choice-1).Single();
        if (_hero.Money >= spell.NeedGold)
        {
            _hero.LearnedSpells.Add(spell);
            _hero.SpellsToLearn.Remove(spell);
            Console.WriteLine($"Ты изучил заклинание {spell.SpellName}!");
            _hero.RemoveMoney(spell.NeedGold);
        }
        Console.WriteLine($"Не хватило золота!");
    }
    
    /// <summary>
    /// Обрабатывает выбор игрока из главного меню
    /// и запускает соответствующее действие.
    /// </summary>
    private static void HandleMainMenuChoice(int choice)
    {
        switch (choice)
        {
            case 1:
                _hero.RestorationOfInitialResourceAndHealth();
                _hero.DisplayCharacterStats();
                break;
            case 2:
                _hero.RestorationOfInitialResourceAndHealth();
                _hero.ShowInventoryMenu();
                break;
            case 3:
                _hero.DisplayHeader();
                _hero.HaveRest();
                break;
            case 4:
                _isCityActive = true;
                while (_isCityActive)
                {
                    _hero.RestorationOfInitialResourceAndHealth();
                    _hero.ShowTownMenu(HandleTownMenuChoice);
                }
                break;
            case 5:
                _hero.DisplayHeader();
                var random =  new Random();
                _hero.StartRandomEncounter(random.Next(1, 4));
                break;
            case 6:
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