using RPG_Game.Characters.Heroes;
using RPG_Game.Items;
using RPG_Game.Messages;

namespace RPG_Game.Characters.Monsters;

/// <summary>
/// Представляет монстра в игре.
/// Наследует общие свойства и поведение от класса Character.
/// </summary>
public abstract class Monster(string name, int health, int armor, int damage, int expReward, int goldReward, int level) 
    : Character(name, 
        health, 
        mana:0, 
        armor)
{
    public int Damage { get; } = damage;
    public int Level { get; private set; } = level; 
    public int ExpReward { get; } = expReward;
    public int GoldReward { get; } = goldReward;
    
    protected override BattleMessages Messages { get; } = new();

    public virtual List<Item> Loot { get; } = new();

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
    
    /// <summary>
    /// Рассчитывает значение характеристики монстра в зависимости от его уровня.
    /// Увеличивает базовое значение характеристики на прирост за каждый новый уровень.
    /// </summary>
    /// <param name="baseValue">Начальное значение характеристики на первом уровне.</param>
    /// <param name="level">Текущий уровень монстра.</param>
    /// <param name="growth">Количество единиц характеристики, добавляемое за уровень.</param>
    protected static int ScaleStat(int baseValue, int level, int growth = 1)
    {
        return baseValue + (level - 1) * growth;
    }
}