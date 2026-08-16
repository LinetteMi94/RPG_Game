namespace RPG_Game;

/// <summary>
/// Отвечает за систему прогрессии героя:
/// хранит текущий уровень, опыт и необходимое количество опыта для следующего уровня.
/// </summary>
public class LevelProgress
{
    public int Level { get; private set; } = 1;
    
    public int Experience { get; private set; } = 0;

    private int ExperienceToNextLevel => Level*50;
    public event Action? LevelUp;
    
    /// <summary>
    /// Добавляет полученный опыт герою.
    /// При достижении необходимого количества опыта повышает уровень.
    /// </summary>
    public void AddExperience(int experience)
    {
        Experience += experience;
        Console.WriteLine($"Получено опыта: {experience}");
        while (Experience >= ExperienceToNextLevel) 
        {
            Experience -= ExperienceToNextLevel;
            Level++;
            Console.WriteLine($"Героем получен {Level} уровень!");
            LevelUp?.Invoke();
        }
    }
}