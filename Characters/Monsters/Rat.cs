using RPG_Game.Characters.Heroes;

namespace RPG_Game.Characters.Monsters;

/// <summary>
/// Представляет обычную крысу — слабого противника начального уровня.
/// Обладает низким запасом здоровья и наносит небольшой физический урон.
/// </summary>
public class Rat() 
        : Monster(name:"Крыса", 
        health:40, 
        armor:5, 
        damage:58, 
        expReward: 10,
        goldReward: 2)
{
        public override void Attack(Hero target)
        { 
                if (IsAlive)
                {
                        Console.WriteLine($"Крыса вцепляется зубами! Нанесено {Damage-target.Armor} урона!");
                        target.TakeDamage(Damage);
                }
        }
}