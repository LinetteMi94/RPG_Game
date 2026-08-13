namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет чернокнижника.
/// Наследует характеристики героя 
/// </summary>
public class Warlock(string name) 
    : Hero(name, 
        health:55, 
        mana: 180, 
        armor:20, 
        level:1, 
        strength:11, 
        agility:18, 
        stamina:21, 
        intellect:24, 
        spirit:22)
{
    public override string ClassName =>  "Чернокнижник";
    
    public override int Damage => (int)Math.Round(Intellect*2.5 + Spirit*0.5);
}