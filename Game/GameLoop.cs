using System;
using System.Threading;
using RPG_Game.Characters.Heroes;
using RPG_Game.Enums;
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
                VisitScrapDealer();
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
        _hero.LearnSpell(spell);
    }

    /// <summary>
    /// Позволяет герою посетить старьёвщика и продать ему разный хлам.
    /// </summary>
    private static void VisitScrapDealer()
    {
        Console.Clear();
        Console.WriteLine("Ты заходишь в небольшую лавку. За прилавком стоит торговец и внимательно рассматривает тебя.\n");
        Console.WriteLine("Старьёвщик: Есть что-нибудь на продажу?");
        Console.WriteLine("1. Да\n2. Нет");
        var choice = InputValidator.GetValidInput(2);
        if (choice == 2)
        {
            Console.WriteLine("Старьёвщик: Как знаешь. Приходи, когда захочешь избавиться от чего-нибудь ненужного.");
            return;
        }
        Console.WriteLine("Старьёвщик: Показывай. За хорошие вещи дам приличную цену. За откровенный хлам... ну, тоже что-нибудь дам.\n");
        while (true)
        {
            var items = _hero.Inventory.Where(x => x.Type is ItemTypes.Junk or ItemTypes.Rare or ItemTypes.Valuable && x.Price > 0).ToArray();
            if (!items.Any())
                    {
                        Console.WriteLine("Вы гордо показываете пустой рюкзак.");
                        Console.WriteLine("Старьёвщик окидывает взглядом содержимое твоего рюкзака.");
                        Console.WriteLine("Старьёвщик: Вижу, продавать тебе пока нечего. Загляни позже.");
                        return;
                    } 
            _hero.ShowItems(items);
            Console.WriteLine("Старьёвщик: Ну что, что из этого ты готов мне продать?");
            Console.WriteLine("\nВыбери вещь для продажи (0 - выход в город)");
            var choiceItem = InputValidator.GetValidInput(items.Length, 0);
            if (choiceItem == 0)
            {
                Console.WriteLine("Старьёвщик: Ну что ж, до встречи. Не выбрасывай всякие безделушки, лучше неси их мне.");
                Console.WriteLine("Вы выходите из лавки.");
                return;
            }
            var item = items[choiceItem - 1];
            _hero.RemoveItem(item,true);
            Console.WriteLine("Нажми любую клавишу для продолжения...");
            Console.ReadKey();
        }
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