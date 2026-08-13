using RPG_Game.Interfaces;
using RPG_Game.Characters.Monsters;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет героя игры.
/// Наследует общие свойства и поведение от класса Character.
/// </summary>
public abstract class Hero(string name, int health, int mana, int armor, int level, 
    int strength, int agility, int stamina, int intellect, int spirit) 
    : Character(name, health, mana, armor, level)
{
    public int Strength { get; } = strength;
    public int Agility { get; } = agility;
    public int Stamina { get; } = stamina;
    public int Intellect { get; } = intellect;
    public int Spirit { get; } = spirit;
    private int Score  { get; } = 0;
    public abstract string ClassName { get; }
    public abstract int Damage { get; }

    public void Attack(Monster target)
    {
        if (IsAlive) target.TakeDamage(Damage);
    }
    
    public override void DisplayCharacterStats()
    { 
        Console.WriteLine($"Персонаж: {name}, {ClassName}, {Level} уровень");
        Console.WriteLine($"Очки опыта: {Score}");
        base.DisplayCharacterStats();
        Console.WriteLine($"Сила: {Strength}, Ловкость: {Agility}, Выносливость: {Stamina}, Интеллект: {Intellect}, Дух: {Spirit}");
        Console.WriteLine();
    }
}