using RPG_Game.Characters.Monsters;
using RPG_Game.Interfaces;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет шамана — повелителя стихий, использующего силу природы.
/// Может применять магические атаки и восстанавливать здоровье союзников.
/// </summary>
public class Shaman(string name) 
    : Hero(name, 
            health:55, 
            mana: 150, 
            armor:20, 
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
    
    public override void Attack(Monster target)
    {
        if (IsAlive)
        {
            Console.WriteLine($"{Name} призывает силу стихий и поражает врага молнией! Нанесено {Damage - target.Armor} урона!");
            target.TakeDamage(Damage);
        }
    }
}