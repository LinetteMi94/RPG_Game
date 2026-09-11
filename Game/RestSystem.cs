using System;
using System.Threading;
using RPG_Game.Characters.Heroes;
using RPG_Game.Interfaces;

namespace RPG_Game.Game;

/// <summary>
/// Управляет процессом отдыха героя.
/// Во время отдыха восстанавливает здоровье и ману персонажа.
/// </summary>
public static class RestSystem
{
    /// <summary>
    /// Запускает отдых героя и восстанавливает его ресурсы.
    /// </summary>
    public static void HaveRest(this Hero hero)
    {
        Console.WriteLine($"{hero.Name} присаживается у костра и довольно вздыхает");
        Console.WriteLine("Отдых будет длиться 10 секунд!");
        Thread.Sleep(10000);
        hero.RestoreFullHealth();
        if (hero is IResourсeCharacter user && user is not Ranger or Pirate)
        {
            user.RestoreFullResource();
            Console.WriteLine($"Здоровье и {hero.ResourceName} {hero.Name} полностью восстановлены!");
        }
        else Console.WriteLine($"Здоровье {hero.Name} полностью восстановлено!");
        
    }
}