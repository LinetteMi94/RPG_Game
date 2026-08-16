namespace RPG_Game.Progression;

/// <summary>
/// Хранит настройки роста характеристик героя при повышении уровня.
/// Определяет, насколько увеличиваются основные характеристики персонажа.
/// </summary>
public class StatGrowth(
    int strengthMultiplier,
    int agilityMultiplier,
    int staminaMultiplier,
    int intellectMultiplier,
    int spiritMultiplier,
    int armorMultiplier)
{
    public int StrengthMultiplier { get; } = strengthMultiplier;
    public int AgilityMultiplier { get; } = agilityMultiplier;
    public int StaminaMultiplier { get; } = staminaMultiplier;
    public int IntellectMultiplier { get; } = intellectMultiplier;
    public int SpiritMultiplier { get; } = spiritMultiplier;
    public int ArmorMultiplier { get; } = armorMultiplier;
}