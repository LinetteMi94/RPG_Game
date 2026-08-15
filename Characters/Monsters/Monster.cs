using RPG_Game.Characters.Heroes;
    
namespace RPG_Game.Characters.Monsters;

/// <summary>
/// Представляет монстра в игре.
/// Наследует общие свойства и поведение от класса Character.
/// </summary>
public abstract class Monster(string name, int health, int armor, int damage, int expReward, int goldReward) 
    : Character(name, 
        health, 
        mana:0, 
        armor)
{
    public int Damage { get; } = damage;
    public int Level { get; private set; } = 1; 
    public int ExpReward { get; } = expReward;
    public int GoldReward { get; } = goldReward;

    public override void DisplayCharacterStats()
    {
        
        Console.Write($"Монстр: {name}, {Level} уровень - ");
        base.DisplayCharacterStats();
        Console.WriteLine($"Броня: {Armor}");
        Console.WriteLine();
    }

    public abstract void Attack(Hero target);
    public virtual void TakeDamage(int damage) => base.TakeDamage(damage);
}