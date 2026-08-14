using RPG_Game.Interfaces;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет паладина.
/// Наследует характеристики героя и реализует способность лечить персонажей.
/// </summary>
public class Paladin(string name) 
    : Hero(name, 
            health:56, 
            mana: 120, 
            armor:20, 
            level:1, 
            strength:22, 
            agility:13, 
            stamina:22, 
            intellect:20, 
            spirit:18), 
        IHealer<Hero>
{
    public override string ClassName =>  "Паладин";
    
    public override int Damage => (int)Math.Round(Strength*1.5 + Intellect);
    public int HealPower => (Intellect + Strength)/2;
    
    public void Heal() => RestoreHealth(HealPower);
    
    public void Heal(Hero hero) => hero.RestoreHealth(HealPower);
}