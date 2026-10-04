using System;
using System.Collections.Generic;
using RPG_Game.Characters.Monsters;
using RPG_Game.Enums;
using RPG_Game.Interfaces;
using RPG_Game.Items;
using RPG_Game.Magic;
using RPG_Game.Messages;
using RPG_Game.Progression;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет героя игры.
/// Наследует общие свойства и поведение от класса Character.
/// </summary>
public abstract class Hero : Character, IResourсeCharacter
{
    protected internal int Strength { get; protected set; }
    protected internal int Agility { get; set; }
    protected internal int Stamina { get; set; }
    protected internal int Intellect { get; protected set; }
    protected internal int Spirit { get; set; }

    protected virtual StatGrowth StatGrowth { get; }

    protected internal int Money { get; set; }

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
    
    public List<Item> Inventory { get; } = new ();

    protected internal abstract string ClassName { get; }
    protected abstract string NoResourceMessage { get; }
    private int Damage { get; set; }
    public abstract Resources ResourceName { get; }
    public abstract int Resource { get; set; }
    public abstract int MaxResource { get; set; }
    public abstract List<Spell> LearnedSpells  { get; set; }
    public abstract List<Spell> SpellsToLearn  { get; set; }

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
    /// Добавляет деньги в кошелёк героя
    /// </summary>
    protected internal void AddMoney(int money) => Money += money;
    
    /// <summary>
    /// Выполняет атаку выбранного противника.
    /// Рассчитывает нанесённый урон и выводит соответствующее сообщение.
    /// </summary>
    protected internal void Attack(Monster target, Spell? spell, bool ignoreArmor = false)
    {
        if(Resource >= spell.NeedResource)
        {
            Resource -= spell.NeedResource;
            Damage = spell.GetDamage(this);
            spell.Sound.PlayCastSound();
            if (Damage > target.Armor)
            {
                spell.Messages.ShowDamageMessage();
                Console.WriteLine($"{Name} наносит {Damage - target.Armor} урона {target.Name}!");
                spell.Sound.PlayHitSound();
                target.TakeDamage(Damage, ignoreArmor);
                if (this is IResourсeCharacter user) user.RestoreResource(spell.GiveResource);
            }
            else spell.Messages.ShowMissMessage();
        }
        else Console.WriteLine(NoResourceMessage);
    }

    /// <summary>
    /// Выводит информацию о персонаже:
    /// характеристики, уровень, здоровье, ману и другие параметры.
    /// </summary>
    public override void DisplayCharacterStats()
    {
        Console.Clear();
        Console.WriteLine($"Персонаж: {Name}, {ClassName}, {Level.Level} уровень");
        Console.WriteLine($"Здоровье: {Health}/{MaxHealth}");
        Console.WriteLine($"{ResourceName}: {Resource}/{MaxResource}");
        Console.WriteLine($"Очки опыта: {Level.Experience}, Золотых монет: {Money}");
        Console.WriteLine($"Броня: {Armor}, Сила: {Strength}, Ловкость: {Agility}, Выносливость: {Stamina}, Интеллект: {Intellect}, Дух: {Spirit}");
        Console.WriteLine();
        Console.WriteLine("Известные заклинания:");
        ShowSpells(LearnedSpells);
    }

    /// <summary>
    /// Изучает заклинание, проверяя наличие необходимого количества золота и списывая его стоимость.
    /// </summary>
    /// <param name="spell">Заклинание, которое герой изучает.</param>
    public void LearnSpell(Spell spell)
    {
        if (Money >= spell.NeedGold)
        {
            LearnedSpells.Add(spell);
            SpellsToLearn.Remove(spell);
            Console.WriteLine($"Ты изучил заклинание {spell.SpellName}!");
            RemoveMoney(spell.NeedGold);
            return;
        }
        Console.WriteLine($"Не хватило золота!");
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
        RestoreFullHealth();
        if (this is IResourсeCharacter user && user is not Ranger or Pirate)
        {
            user.IncreaseMaxResource(level*StatGrowth.ResourceMultiplier);
            user.RestoreFullResource();
        }
    }
    
    /// <summary>
    /// Удаляет указанный предмет из инвентаря героя.
    /// </summary>
    /// <param name="item">Предмет, который необходимо удалить из инвентаря.</param>
    /// <param name="_isForSelling">Указывает, удаляется ли предмет в связи с его продажей.</param>
    public void RemoveItem(Item item, bool _isForSelling = false)
    {
        Inventory.Remove(item);
        if (!_isForSelling)
        {
            Console.WriteLine($"{item.Name} выброшен из рюкзака\n");
            return;
        }
        Money += item.Price;
        Console.WriteLine($"Вы продали {item.Name}! Получено {item.Price} зол.\n");
        Console.WriteLine();
    }
    
    /// <summary>
    /// Отнимает деньги из кошелька героя
    /// </summary>
    protected internal void RemoveMoney(int money) => Money -= money;
    
    /// <summary>
    /// Восстанавливает начальное значение ресурса и здоровья во время спокойного путешествия игрока раз в ход
    /// </summary>
    public void RestorationOfInitialResourceAndHealth()
    {
        var resourceForRestoration = (int)Math.Round(MaxResource*0.02);
        var healthForRestoration = (int)Math.Round(MaxHealth*0.02);
        Health += healthForRestoration;
        if(Health > MaxHealth) Health = MaxHealth;
        if (ClassName == "Пират" || ClassName == "Воин" || ClassName == "Циркач")
        {
            Resource -= resourceForRestoration;
            if(Resource < 0) Resource = 0;
        }
        else
        {
            Resource += resourceForRestoration;
            if(Resource > MaxResource) Resource = MaxResource;
        }
    }
    
    /// <summary>
    /// Отображает список предметов, находящихся в инвентаре героя.
    /// </summary>
    public void ShowInventory()
    {
        if (Inventory.Count != 0)
        {
           Console.WriteLine($"🎒 Инвентарь {Name}:");
           ShowItems(Inventory.ToArray());
        }
        else Console.WriteLine($"🎒 Инвентарь {Name} пуст.");
    }
    
    /// <summary>
    /// Отображает список доступных предметов.
    /// </summary>
    /// <param name="items">Массив предметов для отображения.</param>
    public void ShowItems(Item[] items)
    {
        if (items.Length == 0) return;
        int number = 1;
        foreach (Item item in items)
        { 
            Console.Write($"{number++}. ");
            item.ShowDescription();
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Выводит на экран список заклинаний с учётом режима отображения.
    /// </summary>
    /// <param name="spells">Список заклинаний для отображения.</param>
    /// <param name="_isForLearning">Указывает, отображаются ли заклинания для изучения.</param>
    public void ShowSpells(List<Spell> spells, bool _isForLearning = false)
    {
        var counter = 0;
        foreach (var spell in spells)
        {
            counter++;
            Console.Write($"{counter}. {spell.SpellName}   ");
            Console.Write($"Наносит урона: {spell.GetDamage(this)}   ");
            if (spell is { NeedResource: 0, GiveResource: 0 })
            {
                Console.WriteLine();
                continue;
            }
            Console.WriteLine(spell.NeedResource > 0
                ? $"Требуется: {ResourceName} {spell.NeedResource}"
                : $"Даёт: {ResourceName} {spell.GiveResource}");
            if (_isForLearning) Console.WriteLine($"Стоимость обучения: {spell.NeedGold} зол.   (В наличии {Money} зол.)");
        }
    }
    
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
    
   
}