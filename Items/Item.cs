namespace RPG_Game.Items;

/// <summary>
/// Представляет предмет
/// Содержит название, описание и стоимость предмета.
/// </summary>
public class Item(string name, string description, double price = 0)
{
    public string Name { get; } = name;
    private string Description { get; } = description;
    private double Price { get; } = price;

    /// <summary>
    /// Возвращает информацию о предмете:
    /// название, описание и стоимость.
    /// </summary>
    public void ShowDescription() 
    {
        Console.WriteLine($"{Name} | {Description} | Цена: {Price} золотых");
    }
}