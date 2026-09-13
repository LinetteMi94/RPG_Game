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
    public static void ShowMainMenu(this Hero hero, Action<string> handleChoice)
    {
        DisplayHeader(hero);
        Console.WriteLine($"Что ты хочешь сделать сейчас {hero.Name}?");
        Console.WriteLine("1. Посмотреть карточку героя");
        Console.WriteLine("2. Посмотреть инвентарь");
        Console.WriteLine("3. Отдохнуть");
        Console.WriteLine("4. Отправиться навстречу приключениям");
        Console.WriteLine("5. Выйти из игры");
        
        var choice = Console.ReadLine();
        handleChoice(choice);
        
        //Console.WriteLine("Нажми любую клавишу для продолжения...");
        //Console.ReadKey();
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
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Console.WriteLine($"Введи порядковый номер ненужного хлама, {hero.Name}");
                if (int.TryParse(Console.ReadLine(), out int number) &&
                    number >= 1 &&
                    number <= hero.Inventory.Count)
                {
                    Item item = hero.Inventory[number - 1];
                    hero.RemoveItem(item);
                }
                else Console.WriteLine("Ты выкинул что-то ненужное... Но что же это было?");
                break;
            case "2":
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
            choice = InputValidator.GetValidInput(null,5);
        }
        else choice = InputValidator.GetValidInput(null,4);
        handleChoice(choice);
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
            Console.Write($"{j+1}. {hero.LearnedSpells[j].SpellName}");
            if (hero.LearnedSpells[j].NeedResource != 0)
            {
                Console.Write($"   ({hero.ResourceName}: {hero.LearnedSpells[j].NeedResource})");
            }

            var maxDamage = hero.LearnedSpells[j].GetDamage(hero);
            var minDamage = maxDamage - monster.Armor;
            if (minDamage<0) minDamage = 0;
            Console.WriteLine($"   Урон: {minDamage} - {maxDamage}");
        }
        Console.WriteLine($"{counter}. Назад");
        int choice = InputValidator.GetValidInput(null,counter);
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
}