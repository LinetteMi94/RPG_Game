using System;
using System.Collections.Generic;
using RPG_Game.Characters.Monsters;
using RPG_Game.Interfaces;
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

    protected virtual StatGrowth StatGrowth { get; }

    protected internal int Money { get; private set; }

    public LevelProgress Level { get; } = new();

    protected Hero(
        string name,
        int health,
        int armor,
        int strength,
        int agility,
        int stamina,
        int intellect,
        int spirit)
        : base(name, health, armor)
    {
        Strength = strength;
        Agility = agility;
        Stamina = stamina;
        Intellect = intellect;
        Spirit = spirit;
        Level.LevelUp += OnLevelUp;
    }

    protected override BattleMessages Messages { get; } = new();
    public List<Item> Inventory { get; } = new ();

    protected abstract string ClassName { get; }
    protected abstract int Damage { get; set; }

    /// <summary>
    /// Выполняет атаку выбранного противника.
    /// Рассчитывает нанесённый урон и выводит соответствующее сообщение.
    /// </summary>
    protected virtual void Attack(Monster target, bool ignoreArmor = false)
    {
        if (IsAlive)
        {
            if (Damage > target.Armor)
            {
                Messages.ShowDamageMessage();
                Console.WriteLine($"{Name} наносит {Damage - target.Armor} урона {target.Name}!");
                target.TakeDamage(Damage, ignoreArmor);
                Console.WriteLine($"{target.Name}, здоровье {target.Health}/{target.MaxHealth}!");
                if (this is IManaUser manner) Console.WriteLine($"{Name} мана : {manner.Mana}/{manner.MaxMana}!");
            }
            else Messages.ShowMissMessage();
        }
    }

    /// <summary>
    /// Выполняет действия при повышении уровня:
    /// увеличивает характеристики, здоровье и другие параметры героя.
    /// </summary>
    protected virtual void OnLevelUp()
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
    }
    
    /// <summary>
    /// Добавляет деньги в кошелёк героя
    /// </summary>
    protected internal void AddMoney(int money) => Money += money;
    
    /// <summary>
    /// Отнимает деньги из кошелька героя
    /// </summary>
    protected internal void RemoveMoney(int money) => Money -= money;

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
    internal void AddItem(Item item)
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
        Console.WriteLine($"Очки опыта: {Level.Experience}, Золотых монет: {Money}");
        Console.WriteLine($"Броня: {Armor}, Сила: {Strength}, Ловкость: {Agility}, Выносливость: {Stamina}, Интеллект: {Intellect}, Дух: {Spirit}");
        Console.WriteLine();
    }
    
    /// <summary>
    /// Отображает меню способностей персонажа и обрабатывает выбор игрока.
    /// </summary>
    public abstract void ShowAbilities(int choose, Monster target);
}