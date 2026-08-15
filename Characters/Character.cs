namespace RPG_Game.Characters;

/// <summary>
/// Базовый абстрактный класс для всех персонажей игры.
/// Содержит общие свойства и методы героя и монстра.
/// </summary>
public abstract class Character(string name, int health, int mana, int armor)
{
    public string Name { get; } = name;
    public int Health { get; protected set; } = health;
    public int Mana { get; private set; } = mana;
    public int Armor { get; protected set; } = armor;
    public bool IsAlive => Health > 0;
    public int MaxHealth { get; private set; } = health;
    protected int MaxMana { get; private set; } = mana;
    
    
    /// <summary>
    /// Уменьшает здоровье персонажа на указанное количество.
    /// </summary>
    public void TakeDamage(int damage, bool ignoreArmor = false)
    {
        if (damage < 0)
        {
            throw new ArgumentException("Damage cannot be negative");
        }
        if (ignoreArmor) Health -= damage;
        else
        {
            int realDamage = damage - armor;
            if (realDamage > 0) Health -= realDamage;
        }
        if (Health <= 0) Health = 0;
    }

    /// <summary>
    /// Выводит на консоль характеристики персонажа
    /// </summary>
    public virtual void DisplayCharacterStats()
    {
        if (IsAlive) Console.WriteLine("Жив");
        else Console.WriteLine("Мёртв");
        Console.WriteLine($"Здоровье: {Health}/{MaxHealth}");
    }
    
    /// <summary>
    /// Увеличивает здоровье указанного персонажа на указанное количество.
    /// </summary>
    public void RestoreHealth(int amount)
    {
        Health += amount;
        if (Health > MaxHealth) Health = MaxHealth;
    }
    
    /// <summary>
    /// Увеличивает ману указанного персонажа на указанное количество.
    /// </summary>
    public void RestoreMana(int amount)
    {
        Mana += amount;
        if (Mana > MaxMana) Mana = MaxMana;
    }

    protected void IncreaseMaxHealth(int amount) => MaxHealth += amount;
    protected void IncreaseMaxMana(int amount) => MaxMana += amount;
}