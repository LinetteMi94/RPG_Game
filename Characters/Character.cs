using System;
using RPG_Game.Messages;

namespace RPG_Game.Characters;

/// <summary>
/// Базовый абстрактный класс для всех персонажей игры.
/// Содержит общие свойства и методы героя и монстра.
/// </summary>
public abstract class Character(string name, int health, int armor)
{
    public string Name { get; } = name;
    public int Health { get; protected set; } = health;
    public int Armor { get; protected set; } = armor;
    public bool IsAlive => Health > 0;
    public int MaxHealth { get; private set; } = health;
    
    
    protected abstract BattleMessages Messages { get; } 
    
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
    public virtual void DisplayCharacterStats(){}
    
    /// <summary>
    /// Увеличивает здоровье указанного персонажа на указанное количество.
    /// </summary>
    public void RestoreHealth(int amount)
    {
        Health += amount;
        if (Health > MaxHealth) Health = MaxHealth;
    }
    
    /// <summary>
    /// Полностью восстанавливает здоровье указанного персонажа.
    /// </summary>
    protected internal void RestoreFullHealth()
    {
        Health = MaxHealth;
    }
    

    protected void IncreaseMaxHealth(int amount) => MaxHealth += amount;
}