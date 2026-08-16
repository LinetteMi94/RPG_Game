using RPG_Game.Characters.Heroes;
using RPG_Game.Items;

namespace RPG_Game.Game;

/// <summary>
/// Отвечает за отображение игровых меню и обработку выбора игрока.
/// </summary>
public class GameMenu
{
    /// <summary>
    /// Отображает главное меню игры и показывает доступные действия игрока.
    /// </summary>
    public void ShowMainMenu(Hero hero, Action<string> handleChoice)
    {
        Console.Clear();
        Console.WriteLine($"Что ты хочешь сделать сейчас {hero.Name}?");
        Console.WriteLine("1. Посмотреть карточку героя");
        Console.WriteLine("2. Посмотреть инвентарь");
        Console.WriteLine("3. Отдохнуть");
        Console.WriteLine("4. Сразиться с монстром");
        Console.WriteLine("5. Выйти из игры");
        
        var choice = Console.ReadLine();
        handleChoice(choice);
        
        Console.WriteLine("Нажми любую клавишу для продолжения...");
        Console.ReadKey();
    }
    
    public void ShowInventoryMenu(Hero hero)
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
}