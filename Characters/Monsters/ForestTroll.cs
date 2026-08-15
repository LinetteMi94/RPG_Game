using RPG_Game.Characters.Heroes;

namespace RPG_Game.Characters.Monsters;

/// <summary>
/// Представляет лесного тролля — свирепого обитателя лесов.
/// При низком уровне здоровья впадает в ярость и наносит увеличенный урон.
/// </summary>
public class ForestTroll()
    : Monster(name:"Лесной тролль", 
        health:140, 
        armor:20, 
        damage:28, 
        expReward: 50,
        goldReward: 25)
{
    private readonly double _berserkHealthPercent = 0.3;
    
    private readonly double _berserkDamageMultiplier = 1.5;
    
    public override void Attack(Hero target)
    {
        var realDamage = Damage;
        if (Health < MaxHealth * _berserkHealthPercent)
        {
            realDamage = (int)Math.Round(Damage*_berserkDamageMultiplier);
            Console.WriteLine("🌲🧌 Лесной тролль впадает в ярость! Его глаза наливаются кровью, а удары становятся сильнее!");
        }
        if (IsAlive)
        {
            if (realDamage > target.Armor) Console.WriteLine($"🌲🧌 Лесной тролль с рыком обрушивает кулак на героя! Нанесено {realDamage-target.Armor} урона!");
            else Console.WriteLine($"🌲🧌 Лесной тролль с рыком обрушивает кулак на героя и промахивается!");
            target.TakeDamage(realDamage);
        }
    }
}