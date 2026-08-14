using RPG_Game.Characters.Monsters;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет воина — мастера ближнего боя с высокой силой и выносливостью.
/// Наносит мощные физические атаки и способен выдерживать большой урон.
/// </summary>
public class Warrior(string name)
    : Hero(name, 
        health:57, 
        mana: 0, 
        armor:28, 
        strength:23, 
        agility:20, 
        stamina:25, 
        intellect:16, 
        spirit:16)
{
    public override string ClassName =>  "Воин";
    
    public override int Damage => Strength*2;
    
    public override void Attack(Monster target)
    {
        if (IsAlive)
        {
            Console.WriteLine($"{Name} впадает в боевую ярость и наносит яростный удар! Нанесено {Damage - target.Armor} урона!");
            target.TakeDamage(Damage);
        }
    }
}