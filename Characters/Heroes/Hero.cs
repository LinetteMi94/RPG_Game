using RPG_Game.Characters.Monsters;
using RPG_Game.Items;
using RPG_Game.Messages;
using RPG_Game.Progression;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет героя игры.
/// Наследует общие свойства и поведение от класса Character.
/// </summary>
public abstract class Hero : Character
{
    protected int Strength { get; private set; }
    protected int Agility { get; private set; }
    protected int Stamina { get; private set; }
    protected int Intellect { get; private set; }
    protected int Spirit { get; private set; }

    private StatGrowth StatGrowth { get; }

    private int Money { get; set; }

    public LevelProgress Level { get; } = new();

    protected Hero(
        string name,
        int health,
        int mana,
        int armor,
        int strength,
        int agility,
        int stamina,
        int intellect,
        int spirit,
        StatGrowth statGrowth)
        : base(name, health, mana, armor)
    {
        Strength = strength;
        Agility = agility;
        Stamina = stamina;
        Intellect = intellect;
        Spirit = spirit;
        StatGrowth = statGrowth;
        Level.LevelUp += OnLevelUp;
    }

    protected override BattleMessages Messages { get; } = new();
    public List<Item> Inventory { get; } = new ();

    protected abstract string ClassName { get; }
    protected abstract int Damage { get; }

    /// <summary>
    /// Выполняет атаку выбранного противника.
    /// Рассчитывает нанесённый урон и выводит соответствующее сообщение.
    /// </summary>
    public virtual void Attack(Monster target)
    {
        if (IsAlive)
        {
            if (Damage > target.Armor)
            {
                Messages.ShowDamageMessage();
                Console.WriteLine($"{Name} наносит {Damage - target.Armor} урона {target.Name}!");
                target.TakeDamage(Damage);
                Console.WriteLine($"{target.Name}, здоровье {target.Health}/{target.MaxHealth}!");
            }
            else Messages.ShowMissMessage();
        }
    }

    /// <summary>
    /// Выполняет действия при повышении уровня:
    /// увеличивает характеристики, здоровье и другие параметры героя.
    /// </summary>
    private void OnLevelUp()
    {
        var level = Level.Level;
        Strength += level * StatGrowth.StrengthMultiplier;
        Agility += level * StatGrowth.AgilityMultiplier;
        Stamina += level * StatGrowth.StaminaMultiplier;
        Intellect += level * StatGrowth.IntellectMultiplier;
        Spirit += level * StatGrowth.SpiritMultiplier;
        Armor += level * StatGrowth.ArmorMultiplier;
        IncreaseMaxHealth(level*StatGrowth.StaminaMultiplier);
        RestoreHealth(MaxHealth);
        if (MaxMana != 0)
        {
            IncreaseMaxMana(level*StatGrowth.IntellectMultiplier);
            RestoreMana(MaxMana);
        }
    }
    
    protected internal void GetMoney(int money) => Money += money;

    /// <summary>
    /// Получает случайный предмет из списка добычи побеждённого монстра
    /// и добавляет его в инвентарь героя.
    /// </summary>
    protected internal void TakeLoot(Monster monster)
    {
        Item item = monster.Loot[new Random().Next(monster.Loot.Count)];
        Console.WriteLine($"🎁 С {monster.Name} выпал предмет: {item.Name}");
        AddItem(item);
    }

    /// <summary>
    /// Добавляет предмет в инвентарь героя.
    /// </summary>
    private void AddItem(Item item)
    {
        Inventory.Add(item);
        item.ShowDescription();
        Console.WriteLine($"{item.Name} добавлен в инвентарь");
        Console.WriteLine();
    }
    
    /// <summary>
    /// Удаляет предмет из инвентаря героя.
    /// </summary>
    public void RemoveItem(Item item)
    {
        Inventory.Remove(item);
        item.ShowDescription();
        Console.WriteLine($"{item.Name} выброшен из рюкзака");
        Console.WriteLine();
    }
    
    /// <summary>
    /// Отображает список предметов, находящихся в инвентаре героя.
    /// </summary>
    public void ShowInventory()
    {
        if (Inventory.Count != 0)
        {
           Console.WriteLine($"🎒 Инвентарь {Name}:");
           int number = 1;
           foreach (Item item in Inventory)
           {
               Console.Write($"{number++}. ");
               item.ShowDescription();
               Console.WriteLine();
           }
        }
        else Console.WriteLine($"🎒 Инвентарь {Name} пуст.");
    }

    /// <summary>
    /// Выводит информацию о персонаже:
    /// характеристики, уровень, здоровье, ману и другие параметры.
    /// </summary>
    public override void DisplayCharacterStats()
    { 
        Console.Write($"Персонаж: {Name}, {ClassName}, {Level.Level} уровень - ");
        base.DisplayCharacterStats();
        if (Mana>0) Console.WriteLine($"Мана: {Mana}/{MaxMana}");
        Console.WriteLine($"Очки опыта: {Level.Experience}, Золотых монет: {Money}");
        Console.WriteLine($"Броня: {Armor}, Сила: {Strength}, Ловкость: {Agility}, Выносливость: {Stamina}, Интеллект: {Intellect}, Дух: {Spirit}");
        Console.WriteLine();
    }
}