using System;
using RPG_Game.Enums;

namespace RPG_Game.Items;

/// <summary>
/// Представляет предмет
/// Содержит название, описание и стоимость предмета.
/// </summary>
public class Item(string name, string description, ItemTypes type, int price = 0)
{
    public string Name { get; } = name;
    public ItemTypes Type { get; set; } = type;
    private string Description { get; } = description;
    public int Price { get; set; } = price;

    /// <summary>
    /// Возвращает информацию о предмете:
    /// название, описание и стоимость.
    /// </summary>
    public void ShowDescription() 
    {
        Console.WriteLine($"{Name} | {Description} | Цена: {Price} золотых");
    }
}