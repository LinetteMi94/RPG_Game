namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет мага.
/// Наследует характеристики героя 
/// </summary>
public class Mage(string name) 
    : Hero(name, 
        health:54, 
        mana: 180, 
        armor:20, 
        level:1, 
        strength:12, 
        agility:20, 
        stamina:20, 
        intellect:24, 
        spirit:22)
{
    public override string ClassName =>  "Маг";
    public override int Damage => Intellect*3;
}