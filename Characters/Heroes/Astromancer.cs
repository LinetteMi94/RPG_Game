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
        health:54, 
        armor:20, 
        strength:12, 
        agility:18, 
        stamina:20, 
        intellect:24, 
        spirit:22)
{
    protected override StatGrowth StatGrowth => new(1, 1, 1, 2, 2, 0, 3);
    protected override string ClassName => "Астромант";
    public override Resources ResourceName => Resources.Эфир;
    public override int Resource { get; set; } = 100;
    public override int MaxResource { get; set; } = 100;
    public override List<Spell> LearnedSpells { get; set; }
    public override List<Spell> SpellsToLearn { get; set; }

    protected override BattleMessages Messages => new()
    {
        DamageMessages =
        {
            "🌌 Астромант обрушивает на врага силу звёзд!",
            "✨ Астральная энергия поражает противника!",
            "🌠 Звёздный луч пронзает врага!",
            "🪐 Астромант призывает силу небес и наносит космический удар!",
            "🌑 Космическая энергия вырывается из рук астроманта и поражает врага!",
            "🌌 Астромант обрушивает на противника силу Вселенной!",
            "☄️ Астральная магия испепеляет противника!",
            "🌠 Звёздная вспышка поражает врага!",
            "✨ Сила звёзд пронзает защиту врага!",
            "🪐 Небесные силы подчиняются воле астроманта и атакуют противника!"
        },
        MissMessages =
        {
            "🌌 Астромант обрушивает на врага силу звёзд, но промахивается!",
            "✨ Астральная энергия проходит мимо противника!",
            "🌠 Звёздный луч пролетает мимо врага!",
            "🪐 Астромант призывает силу небес, но удар не достигает цели!",
            "🌑 Космическая энергия вырывается из рук астроманта, но рассеивается!",
            "🌌 Астромант обрушивает на противника силу Вселенной, но тот уклоняется!",
            "☄️ Астральная магия не достигает противника!",
            "🌠 Звёздная вспышка освещает пространство, но не задевает врага!",
            "✨ Сила звёзд пронзает воздух, но проходит мимо цели!",
            "🪐 Небесные силы атакуют противника, но он успевает уклониться!"
        }
    };
}