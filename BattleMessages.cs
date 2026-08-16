namespace RPG_Game;

public class BattleMessages
{
    public List<string> DamageMessages { get; set; } = new();
    public List<string> MissMessages { get; set; } = new();
    public List<string> HealMessages { get; set; } = new();
    public List<string> SpecialMessages { get; set; } = new();
    private readonly Random _random = new();

    public void ShowDamageMessage()
    {
        string message = DamageMessages[_random.Next(DamageMessages.Count)];
        Console.WriteLine(message);
    }
    
    public void ShowMissMessage()
    {
        string message = MissMessages[_random.Next(MissMessages.Count)];
        Console.WriteLine(message);
    }
    
    public void ShowSpecialMessage()
    {
        string message = SpecialMessages[_random.Next(SpecialMessages.Count)];
        Console.WriteLine(message);
    }
    
    public void ShowHealMessage()
    {
        string message = HealMessages[_random.Next(HealMessages.Count)];
        Console.WriteLine(message);
    }
}