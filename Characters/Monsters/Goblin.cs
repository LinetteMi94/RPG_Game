using RPG_Game.Characters.Heroes;

namespace RPG_Game.Characters.Monsters;

/// <summary>
/// Представляет гоблина — небольшого агрессивного противника начального уровня.
/// Обладает более высокими характеристиками, чем обычные слабые существа.
/// </summary>
public class Goblin() 
    : Monster(name: "Гоблин",
    health: 70,
    armor: 10,
    damage: 15,
    expReward: 20,
    goldReward: 8)
{
    public override void Attack(Hero target)
    { 
        if (IsAlive)
        {
            Console.WriteLine($"Гоблин размахивается ржавым клинком! Нанесено {Damage-target.Armor} урона!");
            target.TakeDamage(Damage);
        }
    }
}