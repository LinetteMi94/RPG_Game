namespace RPG_Game.Interfaces;

public interface IManaUser
{
    int Mana { get; set; }
    int MaxMana { get; set; } 
    int NeedMana { get; set; }
    
    /// <summary>
    /// Увеличивает ману указанного персонажа на указанное количество.
    /// </summary>
    void RestoreMana(int amount)
    {
        Mana += amount;
        if (Mana > MaxMana) Mana = MaxMana;
    }
    
    /// <summary>
    /// Увеличивает максимальное количество маны указанного персонажа на указанное количество.
    /// </summary>
    void IncreaseMaxMana(int amount) => MaxMana += amount;
    
    /// <summary>
    /// Полностью восстанавливает ману указанного персонажа.
    /// </summary>
    void RestoreFullMana()
    {
        Mana = MaxMana;
    }
    
}