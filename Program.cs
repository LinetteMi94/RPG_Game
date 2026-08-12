namespace RPG_Game;

internal static class Program
{
    static void Main(string[] args)
    {
        Hero hero1 = new Hero("Рокки", 100, 5,6);
        Monster goblin = new Monster("Гоблин", 200, 40);
        Monster rat = new Monster("Крыса", 50, 10);
        hero1.TakeDamage(70);
        goblin.TakeDamage(30);
        hero1.Heal(78);
        rat.TakeDamage(30);
        rat.DisplayCharacterStats();
        hero1.DisplayCharacterStats();
        goblin.DisplayCharacterStats();
    }
}