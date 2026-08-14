using RPG_Game.Interfaces;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет шамана.
/// Наследует характеристики героя и реализует способность лечить персонажей.
/// </summary>
public class Shaman(string name) 
    : Hero(name, 
            health:55, 
            mana: 150, 
            armor:20, 
            level:1, 
            strength:16, 
            agility:21, 
            stamina:21, 
            intellect:21, 
            spirit:20), 
        IHealer<Hero>
{
    public override string ClassName =>  "Шаман";
    
    public override int Damage => (int)Math.Round(Intellect*1.5 + Agility);
    
    public int HealPower => (Intellect + Spirit)/2;

    public void Heal() => RestoreHealth(HealPower);
    
    public void Heal(Hero hero) => hero.RestoreHealth(HealPower);
}