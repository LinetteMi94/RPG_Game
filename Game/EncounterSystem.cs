using RPG_Game.Characters.Monsters;

namespace RPG_Game.World;

/// <summary>
/// Управляет случайными встречами игрока с монстрами.
/// Создаёт противников соответствующего уровня в зависимости от уровня героя.
/// </summary>
public class EncounterSystem
{
    /// <summary>
    /// Создаёт случайного монстра для встречи с героем.
    /// Уровень монстра определяется на основе уровня героя.
    /// </summary>
    /// <param name="heroLevel">Текущий уровень героя.</param>
    /// <returns>Случайно выбранный монстр.</returns>
    public Monster GetRandomMonster(int heroLevel)
    {
        int monsterLevel = Math.Max(1, heroLevel + new Random().Next(-2, 3));
        var choice = new Random().Next(100);
        return choice switch
        {
            < 35 => new Rat(monsterLevel),
            < 55 => new Zombie(monsterLevel),
            < 70 => new ForestTroll(monsterLevel),
            < 90 => new Goblin(monsterLevel),
            < 95 => new Leprechaun(monsterLevel),
            _ => new BurningElemental(monsterLevel),
        };
    }
}