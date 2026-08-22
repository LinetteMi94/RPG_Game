using RPG_Game.Characters.Heroes;

namespace RPG_Game.Game;

/// <summary>
/// Управляет процессом отдыха героя.
/// Во время отдыха восстанавливает здоровье и ману персонажа.
/// </summary>
public class RestSystem
{
    /// <summary>
    /// Запускает отдых героя и восстанавливает его ресурсы.
    /// </summary>
    public void Rest(Hero hero)
    {
        Console.WriteLine($"{hero.Name} присаживается у костра и довольно вздыхает");
        Console.WriteLine("Отдых будет длиться 10 секунд!");
        Thread.Sleep(10000);
        hero.RestoreHealth(hero.MaxHealth);
        Console.WriteLine($"Здоровье {hero.Name} полностью восстановлено!");
    }
}