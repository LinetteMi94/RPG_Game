using RPG_Game.Characters.Monsters;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет героя игры.
/// Наследует общие свойства и поведение от класса Character.
/// </summary>

/*
public abstract class Hero(string name, int health, int mana, int armor, 
    int strength, int agility, int stamina, int intellect, int spirit) 
    : Character(name, health, mana, armor)
{
    public int Strength { get; } = strength;
    public int Agility { get; } = agility;
    public int Stamina { get; } = stamina;
    public int Intellect { get; } = intellect;
    public int Spirit { get; } = spirit;
    public int Money { get; private set;} 
    public LevelProgress Level { get; private set; } = CreateLevelProgress();

    private LevelProgress CreateLevelProgress()
    {
        var progress = new LevelProgress();
        progress.LevelUp += OnLevelUp;
        return progress;
    }

    public abstract string ClassName { get; }
    public abstract int Damage { get; }

    public abstract void Attack(Monster target);
    
    public override void DisplayCharacterStats()
    { 
        Console.WriteLine($"Персонаж: {name}, {ClassName}, {Level.Level} уровень");
        Console.WriteLine($"Очки опыта: {Level.Experience}, Золотых монет: {Money}");
        base.DisplayCharacterStats();
        Console.WriteLine($"Сила: {Strength}, Ловкость: {Agility}, Выносливость: {Stamina}, Интеллект: {Intellect}, Дух: {Spirit}");
        Console.WriteLine();
        Level.LevelUp += OnLevelUp;
    }

    protected internal void GetMoney(int money) => Money += money;

    protected virtual void OnLevelUp() {}
}*/

public abstract class Hero : Character
{
    public int Strength { get; protected set; }
    public int Agility { get; protected set; }
    public int Stamina { get; protected set; }
    public int Intellect { get; protected set; }
    public int Spirit { get; protected set; }

    protected StatGrowth StatGrowth { get; }

    public int Money { get; private set; }

    public LevelProgress Level { get; private set; } = new();

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

    protected abstract string ClassName { get; }
    public abstract int Damage { get; }

    public abstract void Attack(Monster target);

    private void OnLevelUp()
    {
        var level = Level.Level;
        Strength += level * StatGrowth.StrengthMultiplier;
        Agility += level * StatGrowth.AgilityMultiplier;
        Stamina += level * StatGrowth.StaminaMultiplier;
        Intellect += level * StatGrowth.IntellectMultiplier;
        Spirit += level * StatGrowth.SpiritMultiplier;
        Armor += level * StatGrowth.ArmorMultiplier;
        IncreaseMaxHealth(10*level*StatGrowth.StaminaMultiplier);
        RestoreHealth(MaxHealth);
        if (Mana != 0)
        {
            IncreaseMaxMana(10*level*StatGrowth.IntellectMultiplier);
            RestoreMana(MaxMana);
        }
    }
    
    protected internal void GetMoney(int money) => Money += money;
    
    public override void DisplayCharacterStats()
    { 
        Console.Write($"Персонаж: {Name}, {ClassName}, {Level.Level} уровень - ");
        base.DisplayCharacterStats();
        if (Mana>0) Console.WriteLine($"Мана: {Mana}/{MaxMana}");
        Console.WriteLine($"Очки опыта: {Level.Experience}, Золотых монет: {Money}");
        Console.WriteLine($"Броня: {Armor}, Сила: {Strength}, Ловкость: {Agility}, Выносливость: {Stamina}, Интеллект: {Intellect}, Дух: {Spirit}");
        Console.WriteLine();
        Level.LevelUp += OnLevelUp;
    }
}