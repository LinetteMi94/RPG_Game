using RPG_Game.Interfaces;
using RPG_Game.Characters.Monsters;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет друида — защитника природы, владеющего силами жизни и зверей.
/// Может использовать природную магию для атаки и восстановления здоровья.
/// </summary>
public class Druid(string name) 
    : Hero(name, 
            health:55, 
            mana: 130, 
            armor:20, 
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
    
    public void Heal() => RestoreHealth(HealPower);
    
    public void Heal(Hero hero) => hero.RestoreHealth(HealPower);
    
    public override void Attack(Monster target)
    {
        if (IsAlive)
        {
            Console.WriteLine($"{Name} призывает силу природы и наносит {Damage - target.Armor} урона!");
            target.TakeDamage(Damage);
        }
    }
}