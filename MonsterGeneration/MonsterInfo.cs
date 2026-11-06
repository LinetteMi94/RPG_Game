using RPG_Game.Characters.Monsters;

namespace RPG_Game.MonsterGeneration;

/// <summary>
/// Описывает условия появления монстра и способ его создания.
/// </summary>
public class MonsterInfo(int minLevel, int maxLevel, Func<int, Monster> createMonster)
{
    public int MinLevel { get; set; } = minLevel;
    public int MaxLevel { get; set; } = maxLevel;
    public Func<int, Monster> Create { get; set; } = createMonster;
}