namespace RPG_Game.Characters;

/// <summary>
/// Базовый абстрактный класс для всех персонажей игры.
/// Содержит общие свойства и методы героя и монстра.
/// </summary>
public abstract class Character(string name, int health, int mana, int armor)
{
    public string Name { get; } = name;
    public int Health { get; set; } = health;
    private int Mana { get; set; } = mana;
    public int Armor { get; } = armor;
    public bool IsAlive => Health > 0;
    protected readonly int _maxHealth = health;
    
    /// <summary>
    /// Уменьшает здоровье персонажа на указанное количество.
    /// </summary>
    public void TakeDamage(int damage, bool ignoreArmor = false)
    {
        if (damage < 0)
        {
            throw new ArgumentException("Damage cannot be negative");
        }
        if(ignoreArmor) Health -= damage;
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
        if (IsAlive) Console.WriteLine("Состояние: Жив");
             else Console.WriteLine("Состояние: Мёртв");
        Console.WriteLine($"Здоровье: {Health}, Броня: {Armor}");
    }
    
    /// <summary>
    /// Увеличивает здоровье указанного персонажа на указанное количество.
    /// </summary>
    public void RestoreHealth(int amount)
    {
        Health += amount;
        if (Health > _maxHealth) Health = _maxHealth;
    }
}