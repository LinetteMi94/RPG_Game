namespace RPG_Game;

public class LevelProgress
{
    public int Level { get; private set; } = 1;
    
    public int Experience { get; private set; } = 0;

    private int ExperienceToNextLevel => Level*50;
    public event Action? LevelUp;
    
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