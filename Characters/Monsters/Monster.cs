using RPG_Game.Interfaces;
using RPG_Game.Characters.Heroes;
    
namespace RPG_Game.Characters.Monsters;

/// <summary>
/// Представляет монстра в игре.
/// Наследует общие свойства и поведение от класса Character.
/// </summary>
public class Monster(string name, int health, int armor, int damage) 
    : Character(name, 
        health, 
        mana:0, 
        armor,
        level:1)
{
    public int Damage { get; } = damage;

    public override void DisplayCharacterStats()
    {
        Console.Write($"Монстр: {name}, ");
        base.DisplayCharacterStats();
        Console.WriteLine();
    }
    
    public void Attack(Hero target)
    {
        if (IsAlive) target.TakeDamage(Damage);
    }
}