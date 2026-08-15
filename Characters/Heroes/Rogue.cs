using RPG_Game.Characters.Monsters;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет разбойника — ловкого бойца, который полагается на скорость и точные удары.
/// Использует ловкость для нанесения повышенного урона.
/// </summary>
public class Rogue(string name)
    : Hero(name,
        health: 55,
        mana: 0,
        armor: 20,
        strength: 18,
        agility: 23,
        stamina: 21,
        intellect: 15,
        spirit: 1,
        new StatGrowth(2,2,1,1,1,1))
{
    protected override string ClassName =>  "Разбойник";
    public override int Damage => Agility*2;
    public override void Attack(Monster target)
    {
        if (IsAlive)
        {
            Console.WriteLine($"{Name} молниеносно наносит удар из тени! Нанесено {Damage - target.Armor} урона!");
            target.TakeDamage(Damage);
        }
    }
}