namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет разбойника.
/// Наследует характеристики героя 
/// </summary>
public class Rogue(string name)
    : Hero(name,
        health: 55,
        mana: 0,
        armor: 20,
        level: 1,
        strength: 18,
        agility: 23,
        stamina: 21,
        intellect: 15,
        spirit: 15)
{
    public override string ClassName =>  "Разбойник";
    public override int Damage => Agility*2;
}