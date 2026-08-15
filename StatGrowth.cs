namespace RPG_Game;

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