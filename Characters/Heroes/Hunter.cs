namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет охотника.
/// Наследует характеристики героя 
/// </summary>
public class Hunter(string name)
    : Hero(name,
        health: 55,
        mana: 90,
        armor: 20,
        level: 1,
        strength: 15,
        agility: 24,
        stamina: 21,
        intellect: 18,
        spirit: 19)
{
    public override string ClassName =>  "Охотник";
    public override int Damage => (int)Math.Round(Agility*1.5 + Intellect*0.5);
}