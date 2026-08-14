using RPG_Game.Interfaces;
using RPG_Game.Characters.Monsters;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет паладина — воина Света, сочетающего защиту и священную силу.
/// Обладает высокой выносливостью и способен поддерживать союзников.
/// </summary>
public class Paladin(string name) 
    : Hero(name, 
            health:56, 
            mana: 120, 
            armor:20, 
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
    
    public override void Attack(Monster target)
    {
        if (IsAlive)
        {
            Console.WriteLine($"{Name} обрушивает молот правосудия! Нанесено {Damage - target.Armor} урона!");
            target.TakeDamage(Damage);
        }
    }
}