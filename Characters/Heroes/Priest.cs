using RPG_Game.Interfaces;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет жреца.
/// Наследует характеристики героя и реализует способность лечить персонажей.
/// </summary>
public class Priest(string name) 
    : Hero(name, 
        health:54, 
        mana: 180, 
        armor:20, 
        level:1, 
        strength:12, 
        agility:18, 
        stamina:20, 
        intellect:24, 
        spirit:22), 
        IHealer<Hero>
{
    public override string ClassName => "Жрец";
    
    public override int Damage => Intellect*2 + Spirit;
    
    public int HealPower => (Intellect + Spirit)/2;
    
    public void Heal() => RestoreHealth(HealPower, this);
    
    public void Heal(Hero hero) => RestoreHealth(HealPower, hero);
}