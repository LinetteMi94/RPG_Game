using System;
using RPG_Game.Characters.Monsters;
using RPG_Game.Enums;
using RPG_Game.Interfaces;
using RPG_Game.Magic;
using RPG_Game.Messages;
using RPG_Game.Progression;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет астроманта — мага, использующего силу звёзд, небесных тел и космической энергии.
/// Способен управлять астральной энергией, обрушивать на противников силу небес и искажать пространство.
/// </summary>
public class Astromancer(string name) 
    : Hero(name, 
        health:50, 
        armor:11, 
        strength:7, 
        agility:18, 
        stamina:15, 
        intellect:34, 
        spirit:23)
{
    protected override StatGrowth StatGrowth => new(1, 1, 1, 4, 2, 1, 3);
    protected override string ClassName => "Астромант";
    public override Resources ResourceName => Resources.Эфир;
    public override int Resource { get; set; } = 100;
    public override int MaxResource { get; set; } = 100;
    public override List<Spell> LearnedSpells { get; set; }
    public override List<Spell> SpellsToLearn { get; set; }
}