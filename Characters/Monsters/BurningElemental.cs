using RPG_Game.Characters.Heroes;

namespace RPG_Game.Characters.Monsters;

/// <summary>
/// Представляет горящего элементаля — существо из огненной энергии.
/// Имеет шанс нанести дополнительный урон огнём во время атаки.
/// </summary>
public class BurningElemental() 
    : Monster(name:"Горящий элементаль", 
        health:100, 
        armor:10, 
        damage:30, 
        expReward: 40,
        goldReward: 15)
{
    private readonly int _fireChance = 30;
    private readonly int _fireDamage = 20;
    
    public override void Attack(Hero target)
    {
        if (IsAlive)
        {
            Console.WriteLine($"🔥🔥🔥 Горящий элементаль делает огненный удар! Нанесено {Damage-target.Armor} урона!");
            target.TakeDamage(Damage);
            
            Random newRandom = new Random();
            bool fireAttack = newRandom.Next(100) < _fireChance;
            if (fireAttack)
            {
                target.TakeDamage(_fireDamage, true);
                Console.WriteLine($"🔥🔥🔥 Горящий элементаль поджигает героя! Нанесено {_fireDamage} урона от огня🔥!");
            }
        }
    }
}