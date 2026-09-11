using RPG_Game.Enums;

namespace RPG_Game.Interfaces;

/// <summary>
/// Представляет персонажа, использующего особый игровой ресурс.
/// Ресурс может использоваться для применения способностей и уникальных механик класса.
/// </summary>
public interface IResourсeCharacter
{
    Resources ResourceName { get; }
    int Resource { get; set; }
    int MaxResource { get; set; } 
    int NeedResource { get; set; }
    
    /// <summary>
    /// Увеличивает ресурс указанного персонажа на указанное количество.
    /// </summary>
    void RestoreResource(int amount)
    {
        Resource += amount;
        if (Resource > MaxResource) Resource = MaxResource;
    }
    
    /// <summary>
    /// Увеличивает максимальное количество ресурса указанного персонажа на указанное количество.
    /// </summary>
    void IncreaseMaxResource(int amount) => MaxResource += amount;
    
    /// <summary>
    /// Полностью восстанавливает ресурс указанного персонажа.
    /// </summary>
    void RestoreFullResource()
    {
        Resource = MaxResource;
    }
}