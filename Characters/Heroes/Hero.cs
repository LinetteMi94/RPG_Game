using RPG_Game.Characters.Monsters;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет героя игры.
/// Наследует общие свойства и поведение от класса Character.
/// </summary>
public abstract class Hero(string name, int health, int mana, int armor, 
    int strength, int agility, int stamina, int intellect, int spirit) 
    : Character(name, health, mana, armor)
{
    public int Strength { get; } = strength;
    public int Agility { get; } = agility;
    public int Stamina { get; } = stamina;
    public int Intellect { get; } = intellect;
    public int Spirit { get; } = spirit;
    public int Score { get; private set; } 
    
    public int Money { get; private set;}
    public int Level { get; private set; } = 1; 
    public abstract string ClassName { get; }
    public abstract int Damage { get; }
    public event Action<Hero> OnLevelUp; 
    

    public abstract void Attack(Monster target);
    
    public override void DisplayCharacterStats()
    { 
        Console.WriteLine($"Персонаж: {name}, {ClassName}, {Level} уровень");
        Console.WriteLine($"Очки опыта: {Score}, Золотых монет: {Money}");
        base.DisplayCharacterStats();
        Console.WriteLine($"Сила: {Strength}, Ловкость: {Agility}, Выносливость: {Stamina}, Интеллект: {Intellect}, Дух: {Spirit}");
        Console.WriteLine();
    }

    protected internal void GetScore(int exp)
    {
        Score += exp;
        Console.WriteLine($"Получено опыта: {exp}");
        if (Score >= 20) 
        {
            Level++;
            Score -= 20;
            OnLevelUp?.Invoke(this);
        }
    }
    
    protected internal void GetMoney(int money) => Money += money;
}