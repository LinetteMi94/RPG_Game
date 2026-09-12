using System;
using RPG_Game.Messages;
using RPG_Game.Progression;
using RPG_Game.Characters.Monsters;
using RPG_Game.Enums;
using RPG_Game.Interfaces;
using RPG_Game.Magic;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет колдуна — мага тёмных искусств, использующего силу Бездны.
/// Наносит магический урон, игнорирующий броню противника.
/// </summary>
public class Warlock(string name) 
    : Hero(name, 
        health:52, 
        armor:13, 
        strength:9, 
        agility:15, 
        stamina:17, 
        intellect:33, 
        spirit:17)
{
    protected override StatGrowth StatGrowth => new(1, 1, 1, 4, 2, 1,3);
    protected override string ClassName =>  "Колдун";
    public override Resources ResourceName => Resources.Мана;
    public override int Resource { get; set; } = 100;
    public override int MaxResource { get; set; } = 100;
    public override List<Spell> LearnedSpells { get; set; }
    public override List<Spell> SpellsToLearn { get; set; }
}