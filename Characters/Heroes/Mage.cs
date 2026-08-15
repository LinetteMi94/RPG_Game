using RPG_Game.Characters.Monsters;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет мага — заклинателя, использующего магическую силу для нанесения урона.
/// Основывается на интеллекте и обладает большим запасом маны.
/// </summary>
public class Mage(string name) 
    : Hero(name, 
        health:54, 
        mana: 180, 
        armor:20,
        strength:12, 
        agility:20, 
        stamina:20, 
        intellect:24, 
        spirit:22,
        new StatGrowth(1,1,1,2,2,0))
{
    protected override string ClassName =>  "Маг";
    public override int Damage => Intellect*3;
    
    public override void Attack(Monster target)
    {
        if (IsAlive)
        {
            Console.WriteLine($"{Name} призывает пламя и поражает врага огненным шаром! Нанесено {Damage - target.Armor} урона!");
            target.TakeDamage(Damage);
        }
    }
}