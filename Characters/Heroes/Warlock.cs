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
        health:55, 
        armor:20, 
        strength:11, 
        agility:18, 
        stamina:21, 
        intellect:24, 
        spirit:22)
{
    protected override StatGrowth StatGrowth => new(1, 1, 1, 2, 2, 0,3);
    protected override string ClassName =>  "Колдун";
    public override Resources ResourceName => Resources.Мана;
    public override int Resource { get; set; } = 100;
    public override int MaxResource { get; set; } = 100;
    public override List<Spell> LearnedSpells { get; set; }
    public override List<Spell> SpellsToLearn { get; set; }
}