namespace RPG_Game.Messages;

public abstract class Messages
{
    /// <summary>
    /// Выводит случайное сообщение из переданного списка.
    /// </summary>
    protected void ShowMessage(List<string> messages)
    {
        string message = messages[new Random().Next(messages.Count)];
        Console.WriteLine(message);
    }
}