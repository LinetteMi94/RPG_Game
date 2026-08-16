namespace RPG_Game.Messages;

/// <summary>
/// Содержит боевые сообщения персонажей.
/// Хранит варианты сообщений для различных действий во время боя:
/// атаки, промахов, лечения и особых эффектов.
/// </summary>
public class BattleMessages
{
    public List<string> DamageMessages { get; } = [];
    public List<string> MissMessages { get; } = [];
    public List<string> HealMessages { get; } = [];
    public List<string> SpecialMessages { get; } = [];
    
    /// <summary>
    /// Выводит случайное сообщение из переданного списка.
    /// </summary>
    private void ShowMessage(List<string> messages)
    {
        string message = messages[new Random().Next(messages.Count)];
        Console.WriteLine(message);
    }
    
    /// <summary>
    /// Выводит случайное сообщение успешной атаки.
    /// </summary>
    public void ShowDamageMessage() => ShowMessage(DamageMessages);
    
    /// <summary>
    /// Выводит случайное сообщение о промахе.
    /// </summary>
    public void ShowMissMessage() => ShowMessage(MissMessages);
    
    /// <summary>
    /// Выводит случайное сообщение специального эффекта.
    /// </summary>
    public void ShowSpecialMessage() => ShowMessage(SpecialMessages);
    
    /// <summary>
    /// Выводит случайное сообщение лечения.
    /// </summary>
    public void ShowHealMessage() => ShowMessage(HealMessages);
}