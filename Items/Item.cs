namespace RPG_Game.Items;

public class Item(string name, string description, double price = 0)
{
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    public double Price { get; set; } = price;

    public void ShowDescription() 
    {
        Console.WriteLine($"{Name} | {Description} | Цена: {Price} золотых");
    }
}