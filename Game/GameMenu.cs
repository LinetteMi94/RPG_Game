using System;
using RPG_Game.Characters.Heroes;
using RPG_Game.Characters.Monsters;
using RPG_Game.Input;
using RPG_Game.Interfaces;
using RPG_Game.Items;

namespace RPG_Game.Game;

/// <summary>
/// Отвечает за отображение игровых меню и обработку выбора игрока.
/// </summary>
public static class GameMenu
{
    /// <summary>
    /// Отображает главное меню игры.
    /// </summary>
    public static void ShowMainMenu(this Hero hero, Action<int> handleChoice)
    {
        DisplayHeader(hero);
        Console.WriteLine($"Что ты хочешь сделать сейчас {hero.Name}?");
        Console.WriteLine("1. Посмотреть карточку героя");
        Console.WriteLine("2. Посмотреть инвентарь");
        Console.WriteLine("3. Отдохнуть");
        Console.WriteLine("4. Отправиться в город");
        Console.WriteLine("5. Отправиться навстречу приключениям");
        Console.WriteLine("6. Выйти из игры");
        
        var choice = InputValidator.GetValidInput(6);
        handleChoice(choice);
    }
    
    /// <summary>
    /// Отображает меню инвентаря и обрабатывает выбор игрока.
    /// </summary>
    public static void ShowInventoryMenu(this Hero hero)
    {
        Console.Clear();
        hero.ShowInventory();
        if (hero.Inventory.Count == 0) return;
        Console.WriteLine();
        Console.WriteLine($"Что ты хочешь сделать {hero.Name}?");
        Console.WriteLine("1. Выкинуть предмет");
        Console.WriteLine("2. Выйти из инвентаря");
        var choice = InputValidator.GetValidInput(2);
        switch (choice)
        {
            case 1:
                Console.WriteLine($"Введи порядковый номер ненужного хлама, {hero.Name}");
                var number = InputValidator.GetValidInput(hero.Inventory.Count);
                Item item = hero.Inventory[number - 1];
                hero.RemoveItem(item);
                break;
            case 2:
                break;
        }
    }
    
    /// <summary>
    /// Отображает меню битвы.
    /// </summary>
    public static void ShowBattleMenu(this Hero? hero, Monster? monster, Action<int> handleChoice)
    {
        DisplayHeader(hero, monster);
        Console.WriteLine($"Что ты хочешь сделать в битве c {monster.Name}, {hero.Name}?");
        Console.WriteLine();
        Console.WriteLine("1. Атаковать");
        Console.WriteLine("2. Выпить зелье");
        Console.WriteLine("3. Попытаться сбежать");
        Console.WriteLine("4. Ничего не делать");
        int choice;
        if (hero is IHealer)
        {
            Console.WriteLine("5. Подлечиться");
            choice = InputValidator.GetValidInput(5);
        }
        else choice = InputValidator.GetValidInput(4);
        handleChoice(choice);
        Console.WriteLine("Нажми любую клавишу для продолжения...");
        Console.ReadKey();
    }
    
    /// <summary>
    /// Отображает меню заклинаний.
    /// </summary>
    public static int ShowAttackMenu(this Hero hero, Monster? monster)
    {
        var counter = hero.LearnedSpells.Count + 1;
        DisplayHeader(hero, monster);
        Console.WriteLine($"Каким заклинанием ты хочешь атаковать {monster.Name}?");
        Console.WriteLine();
        for (int j = 0; j < counter-1; j++)
        {
            ShowSpellInformation(hero,monster,j);
        }
        Console.WriteLine($"{counter}. Назад");
        int choice = InputValidator.GetValidInput(counter);
        if(choice == counter) return -1;
        return choice;
    }

    /// <summary>
    /// Выводит на экран заголовок боя с информацией о герое и противнике.
    /// </summary>
    public static void DisplayHeader(this Hero hero, Monster? monster = null)
    {
        Console.Clear();
        Console.WriteLine($"{hero.Name}    Health: {hero.Health}/{hero.MaxHealth}    {hero.ResourceName}: {hero.Resource}/{hero.MaxResource}");
        if (monster != null) Console.WriteLine($"{monster.Name}    Health: {monster.Health}/{monster.MaxHealth}");
        Console.WriteLine();
    }
    
    /// <summary>
    /// Выводит на экран информацию о заклинании.
    /// </summary>
    private static void ShowSpellInformation(Hero hero, Monster? monster, int index)
    {
        Console.Write($"{index+1}. {hero.LearnedSpells[index].SpellName}");
        if (hero.LearnedSpells[index].NeedResource != 0)
        {
            Console.Write($"   ({hero.ResourceName}: {hero.LearnedSpells[index].NeedResource})");
        }
        var maxDamage = hero.LearnedSpells[index].GetDamage(hero);
        var minDamage = maxDamage - monster.Armor;
        if (minDamage<0) minDamage = 0;
        Console.WriteLine($"   Урон: {minDamage} - {maxDamage}");
    }
    
    /// <summary>
    /// Отображает меню города и обрабатывает выбор игрока.
    /// </summary>
    public static void ShowTownMenu(this Hero hero) 
    {
        Console.Clear();
        hero.DisplayHeader();
        Console.WriteLine();
        Console.WriteLine($"Куда ты хочешь направиться {hero.Name}?");
        Console.WriteLine("1. Посетить таверну");
        Console.WriteLine("2. Пойти к аптекарю");
        Console.WriteLine("3. Найти старьёвщика");
        Console.WriteLine("4. Прогуляться");
        Console.WriteLine("5. Зайти к наставнику");
        Console.WriteLine("6. Выйти из города");
        var choice = InputValidator.GetValidInput(6);
        switch (choice)
        {
            case 1:
                // Посетить таверну
                Console.WriteLine("Вы посетили таверну");
                break;
            case 2:
                // Пойти к аптекарю
                Console.WriteLine("Вы пошли к аптекарю");
                break;
            case 3:
                // Найти старьёвщика
                Console.WriteLine("Вы нашли старьёвщика");
                break;
            case 4:
                // Прогуляться
                Console.WriteLine("Вы прогуливаетесь по городу");
                break;
            case 5:
                // Найти наставника
                Console.WriteLine("Вы нашли наставника");
                break;
            case 6:
                Console.WriteLine($"{hero.Name} выходит из города");
                break;
        }
    }
}