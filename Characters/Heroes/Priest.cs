using RPG_Game.Interfaces;
using RPG_Game.Characters.Monsters;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет жреца — целителя, владеющего силами света.
/// Может восстанавливать здоровье союзников и использовать магические атаки.
/// </summary>
public class Priest(string name) 
    : Hero(name, 
        health:54, 
        mana: 180, 
        armor:20, 
        strength:12, 
        agility:18, 
        stamina:20, 
        intellect:24, 
        spirit:22,
        new StatGrowth(1,1,1,2,2,0)), 
        IHealer<Hero>
{
    protected override string ClassName => "Жрец";
    
    public override int Damage => Intellect*2 + Spirit;
    
    public int HealPower => (Intellect + Spirit)/2;
    
    public void Heal() => RestoreHealth(HealPower);
    
    public void Heal(Hero hero) => hero.RestoreHealth(HealPower);
    
    public override void Attack(Monster target)
    {
        if (IsAlive)
        {
            Console.WriteLine($"{Name} направляет силу света и наносит {Damage - target.Armor} урона!");
            target.TakeDamage(Damage);
        }
    }
}