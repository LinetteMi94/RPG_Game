namespace RPG_Game;

public class BattleMessages
{
    public List<string> DamageMessages { get; set; } = new();
    public List<string> MissMessages { get; set; } = new();
    private readonly Random _random = new();

    public void ShowDamageMessage(List<string> damageMessages)
    {
        string message = DamageMessages[_random.Next(DamageMessages.Count)];
        Console.WriteLine(message);
    }
}