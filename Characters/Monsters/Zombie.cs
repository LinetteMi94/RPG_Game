using RPG_Game.Characters.Heroes;

namespace RPG_Game.Characters.Monsters;

/// <summary>
/// Представляет зомби — ожившего мертвеца.
/// Может восстанавливать здоровье во время боя.
/// </summary>
public class Zombie()
    : Monster(name:"Зомби", 
        health:120, 
        armor:15, 
        damage:25, 
        expReward: 35,
        goldReward: 10)
{
    private readonly int _regenerationAmount = 10;

    public override void Attack(Hero target)
    {
        if (IsAlive)
        {
            Console.WriteLine($"Зомби вгрызается в противника! Нанесено {Damage - target.Armor} урона!");
            target.TakeDamage(Damage);
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        Console.WriteLine($"Зомби получает {damage-Armor} урона!");
        if (damage > Armor && Health > 0 && new Random().Next(100) < 30)
        {
            Console.WriteLine($"Зомби восстанавливает свою гнилую плоть... Восстанавлено {_regenerationAmount} здоровья!");
            Health += _regenerationAmount;
        }
    }
}