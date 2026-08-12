namespace RPG_Game;

/// <summary>
/// Представляет монстра в игре.
/// Наследует общие свойства и поведение от класса Character.
/// </summary>
public class Monster(string name, int health, int armor) : Character(name, health)
{
    private int Armor { get; } = armor;
    
    public override void TakeDamage(int damage)
    {
        int realDamage = damage - Armor;
        if (realDamage > 0) base.TakeDamage(realDamage);
    }

    public override void DisplayCharacterStats()
    {
        base.DisplayCharacterStats();
        Console.WriteLine($"Броня: {Armor}");
    }
}