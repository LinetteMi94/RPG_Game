using RPG_Game.Characters.Monsters;

namespace RPG_Game.MonsterGeneration;

/// <summary>
/// Содержит каталог доступных для генерации монстров.
/// </summary>
public static class MonsterCatalog
{
    public static List<MonsterInfo> Monsters =
    [
        new (1, 4, level => new Rat(level)),
        new (3, 8, level => new BurningElemental(level)),
        new (4, 10, level => new ForestTroll(level)),
        new (1, 5, level => new Goblin(level)),
        new (3, 8, level => new Leopard(level)),
        new (3, 9, level => new Leprechaun(level)),
        new (2, 7, level => new Vampire(level)),
        new (1, 6, level => new Zombie(level)),
    ];
}