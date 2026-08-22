using RPG_Game.Characters.Heroes; 
using RPG_Game.World;

namespace RPG_Game.Game;

/// <summary>
/// Управляет основным игровым процессом.
/// Отвечает за запуск игры, взаимодействие игрока с меню
/// и последовательность выполнения игровых действий.
/// </summary>
public class GameLoop
{
    private Hero _hero;
    private bool _isRunning;
    private RestSystem _restSystem =  new ();
    private EncounterSystem _encounterSystem = new ();
    private GameMenu _menu = new ();

    public void Start()
    {
        _isRunning = true;
        _hero = CreatePlayer();
        while (_isRunning)
        {
            _menu.ShowMainMenu(_hero, HandleChoice);
            if (!_hero.IsAlive) GameOver();
        }
    }
    
    /// <summary>
    /// Создаёт нового персонажа игрока.
    /// Определяет выбранный класс героя и возвращает соответствующий объект.
    /// </summary>
    private Hero CreatePlayer()
    {
        Console.Write("Введите имя героя: ");
        var heroName = Console.ReadLine();
        Console.WriteLine("Выберите класс героя:");
        Console.WriteLine("1. Друид  2. Охотник  3. Маг  4. Паладин  5. Жрец  6. Разбойник  7. Шаман  8. Чернокнижник  9. Воин");
        var choice = Console.ReadLine();
        
        if(!int.TryParse(choice, out int number) || number > 9 || number < 1)
        {
            Console.WriteLine("Неверный выбор. Будет выбран случайный класс");
            Thread.Sleep(1000);
            choice = new Random().Next(1,10).ToString();
        }
        switch (choice)
        {
            case "1":
                return new Druid(heroName);
            case "2":
                return new Hunter(heroName);
            case "3":
                return new Mage(heroName);
            case "4":
                return new Paladin(heroName);
            case "5":
                return new Priest(heroName);
            case "6":
                return new Rogue(heroName);
            case "7":
                return new Shaman(heroName);
            case "8":
                return new Warlock(heroName);
            case "9":
                return new Warrior(heroName);
            default:
                return null;
        }
    }

    

    /// <summary>
    /// Обрабатывает выбор игрока из главного меню
    /// и запускает соответствующее действие.
    /// </summary>
    private void HandleChoice(string choice)
    {
        switch (choice)
        {
            case "1":
                _hero.DisplayCharacterStats();
                break;
            case "2":
                _menu.ShowInventoryMenu(_hero);
                break;
            case "3":
                _restSystem.Rest(_hero);
                break;
            case "4":
                var monster = _encounterSystem.GetRandomMonster(_hero.Level.Level);
                Console.WriteLine($"Вам повстречался на пути {monster.Name}, {monster.Level} уровень");
                var battle = new Battle();
                battle.OnMonsterDefeated += monster =>
                {
                    _hero.Level.AddExperience(monster.ExpReward);
                    _hero.GetMoney(monster.GoldReward);
                    _hero.TakeLoot(monster);
                };
                battle.Start(_hero, monster);
                break;
            case "5":
                _isRunning = false;
                break;
        }
    }

    private void GameOver()
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