namespace RPG_Game.Interfaces;

/// <summary>
/// Определяет способность персонажа восстанавливать здоровье себе
/// или другому персонажу указанного типа.
/// </summary>
public interface IHealer
{
    int HealPower { get; }
    
    /// <summary>
    /// Восстанавливает здоровье текущего персонажа.
    /// </summary>
    void Heal();
}