namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет воина.
/// Наследует характеристики героя 
/// </summary>
public class Warrior(string name)
    : Hero(name, 
        health:57, 
        mana: 0, 
        armor:20, 
        level:1, 
        strength:23, 
        agility:20, 
        stamina:23, 
        intellect:16, 
        spirit:16)
{
    public override string ClassName =>  "Воин";
    
    public override int Damage => Strength*2;
}