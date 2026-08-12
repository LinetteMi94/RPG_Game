namespace RPG_Game;

/// <summary>
/// Базовый абстрактный класс для всех персонажей игры.
/// Содержит общие свойства и методы героя и монстра.
/// </summary>
public abstract class Character(string name, int health)
{
    private string Name { get; } = name;
    private int Health { get; set; } = health;
    private bool IsAlive => Health > 0;
    private readonly int _maxHealth = health;
    
    /// <summary>
    /// Уменьшает здоровье персонажа на указанное количество.
    /// </summary>
    public virtual void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            throw new ArgumentException("Damage cannot be negative");
        }
        Health -= damage;
        if (Health <= 0) Health = 0;
    }
    
    /// <summary>
    /// Выводит на консоль характеристики персонажа
    /// </summary>
    public virtual void DisplayCharacterStats()
    {
        Console.WriteLine($"Имя: {Name}");
        Console.WriteLine($"Здоровье: {Health}");
        if (IsAlive) Console.WriteLine("Состояние: Жив");
        else Console.WriteLine("Состояние: Мёртв");
    }
    
    /// <summary>
    /// Увеличивает здоровье персонажа на указанное количество.
    /// </summary>
    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Amount cannot be negative");
        }
        Health += amount;
        if (Health > _maxHealth) Health = _maxHealth;
    }
}