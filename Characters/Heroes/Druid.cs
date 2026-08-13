using RPG_Game.Interfaces;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет друида.
/// Наследует характеристики героя и реализует способность лечить персонажей.
/// </summary>
public class Druid(string name) 
    : Hero(name, 
            health:55, 
            mana: 130, 
            armor:20, 
            level:1, 
            strength:15, 
            agility:22, 
            stamina:21, 
            intellect:20, 
            spirit:21), 
        IHealer<Hero>
{
    public override string ClassName => "Друид";
    public override int Damage => Intellect+Agility;
    public int HealPower => (Intellect + Spirit)/2;
    
    public void Heal() => RestoreHealth(HealPower, this);
    
    public void Heal(Hero hero) => RestoreHealth(HealPower, hero);
}