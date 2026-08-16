using RPG_Game.Characters.Heroes;
    
namespace RPG_Game.Characters.Monsters;

/// <summary>
/// Представляет монстра в игре.
/// Наследует общие свойства и поведение от класса Character.
/// </summary>
public abstract class Monster(string name, int health, int armor, int damage, int expReward, int goldReward) 
    : Character(name, 
        health, 
        mana:0, 
        armor)
{
    public int Damage { get; } = damage;
    public int Level { get; private set; } = 1; 
    public int ExpReward { get; } = expReward;
    public int GoldReward { get; } = goldReward;
    
    protected override BattleMessages Messages { get; } = new();

    public override void DisplayCharacterStats()
    {
        
        Console.Write($"Монстр: {name}, {Level} уровень - ");
        base.DisplayCharacterStats();
        Console.WriteLine($"Броня: {Armor}");
        Console.WriteLine();
    }

    public virtual void Attack(Hero target, int? damage = null)
    {
        int realDamage = damage ?? Damage;
        if (IsAlive)
        {
            target.TakeDamage(realDamage);
            if (realDamage > target.Armor)
            {
                Messages.ShowDamageMessage();
                Console.WriteLine($"{Name} наносит {realDamage - target.Armor} урона {target.Name}!");
                Console.WriteLine($"{target.Name}, здоровье {target.Health}/{target.MaxHealth}!");
            }
            else Messages.ShowMissMessage();
            Console.WriteLine();
        }
    }
    
    public virtual void TakeDamage(int damage) => base.TakeDamage(damage);
}