using System;
using RPG_Game.Characters.Monsters;
using RPG_Game.Enums;
using RPG_Game.Magic;
using RPG_Game.Messages;
using RPG_Game.Progression;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет следопыта — дальнего бойца, использующего ловкость и точность.
/// Наносит урон с расстояния и полагается на меткие атаки.
/// </summary>
public class Ranger(string name)
    : Hero(name,
        health: 55,
        armor: 16,
        strength: 18,
        agility: 30,
        stamina: 18,
        intellect: 12,
        spirit: 12)
{
    protected override string ClassName =>  "Следопыт";
    protected override StatGrowth StatGrowth => new(2, 3, 2, 1, 1, 1,1);
    public override Resources ResourceName => Resources.Концентрация;
    public override int Resource { get; set; } = 100;
    public override int MaxResource { get; set; } = 100;
    public override List<Spell> LearnedSpells { get; set; }
    public override List<Spell> SpellsToLearn { get; set; }
}