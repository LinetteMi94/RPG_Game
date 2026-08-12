namespace RPG_Game;

/// <summary>
/// Представляет героя игры.
/// Наследует общие свойства и поведение от класса Character.
/// </summary>
public class Hero(string name, int health, int strength, int agility) : Character(name, health)
{
    private int Strength { get; } = strength;
    private int Agility { get; } = agility;
    private int Score  { get; } = 0;
    
    public override void DisplayCharacterStats()
    {
        base.DisplayCharacterStats();
        Console.WriteLine($"Сила: {Strength}");
        Console.WriteLine($"Ловкость: {Agility}");
        Console.WriteLine($"Очки опыта: {Score}");
    }
    
}