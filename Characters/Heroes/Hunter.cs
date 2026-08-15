using RPG_Game.Characters.Monsters;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет охотника — дальнего бойца, использующего ловкость и точность.
/// Наносит урон с расстояния и полагается на меткие атаки.
/// </summary>
public class Hunter(string name)
    : Hero(name,
        health: 55,
        mana: 90,
        armor: 20,
        strength: 15,
        agility: 24,
        stamina: 21,
        intellect: 18,
        spirit: 19,
        new StatGrowth(1,2,2,1,1,1))
{
    protected override string ClassName =>  "Охотник";
    public override int Damage => (int)Math.Round(Agility*1.5 + Intellect*0.5);
    
    public override void Attack(Monster target)
    {
        if (IsAlive)
        {
            Console.WriteLine($"{Name} выпускает меткую стрелу! Нанесено {Damage - target.Armor} урона!");
            target.TakeDamage(Damage);
        }
    }
}