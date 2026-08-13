namespace RPG_Game.Interfaces;

/// <summary>
/// Определяет способность персонажа восстанавливать здоровье себе
/// или другому персонажу указанного типа.
/// </summary>
public interface IHealer<in T>
{
    int HealPower { get; }
    
    /// <summary>
    /// Восстанавливает здоровье текущего персонажа.
    /// </summary>
    void Heal();
    
    /// <summary>
    /// Восстанавливает здоровье указанному персонажу.
    /// </summary>
    void Heal(T character);
}