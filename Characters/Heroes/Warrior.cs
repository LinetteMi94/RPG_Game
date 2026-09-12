using RPG_Game.Characters.Monsters;
using RPG_Game.Enums;
using RPG_Game.Magic;
using RPG_Game.Messages;
using RPG_Game.Progression;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет воина — мастера ближнего боя с высокой силой, бронёй и выносливостью.
/// Наносит мощные физические атаки и способен выдерживать большой урон.
/// </summary>
public class Warrior(string name)
    : Hero(name, 
        health:70, 
        armor:30, 
        strength:25, 
        agility:15, 
        stamina:28, 
        intellect:8, 
        spirit:12)
{
    protected override StatGrowth StatGrowth => new(3, 1, 3, 1, 1, 2,0);
    protected override string ClassName =>  "Воин";
    public override Resources ResourceName => Resources.Ярость;
    public override int Resource { get; set; } = 0;
    public override int MaxResource { get; set; } = 100;
    public override List<Spell> LearnedSpells { get; set; }
    public override List<Spell> SpellsToLearn { get; set; }
    
}