using RPG_Game.Characters.Monsters;
using RPG_Game.Enums;
using RPG_Game.Magic;
using RPG_Game.Messages;
using RPG_Game.Progression;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет пирата — ловкого бойца, который полагается на скорость и точные удары.
/// Использует ловкость для нанесения повышенного урона.
/// </summary>
public class Pirate(string name)
    : Hero(name,
        health: 55,
        armor: 20,
        strength: 18,
        agility: 23,
        stamina: 21,
        intellect: 15,
        spirit: 12)
{
    protected override string ClassName =>  "Пират";
    protected override StatGrowth StatGrowth => new(2, 2, 1, 1, 1, 1,0);
    public override Resources ResourceName => Resources.Азарт;
    public override int Resource { get; set; } = 0;
    public override int MaxResource { get; set; } = 100;
    public override List<Spell> LearnedSpells { get; set; }
    public override List<Spell> SpellsToLearn { get; set; }
    protected override BattleMessages Messages => new()
    {
        DamageMessages =
        {
            "🗡️ Пират молниеносно наносит удар кинжалом!",
            "🏴‍☠️ Пират обрушивает на врага свой клинок!",
            "⚔️ Пират наносит противнику коварный удар!",
            "🗡️ Острый клинок пронзает врага!",
            "🍾 Пират разбивает бутылку о голову противника!",
            "🏴‍☠️ Пират бросается в атаку и наносит сокрушительный удар!",
            "⚔️ Клинок пирата рассекает защиту врага!",
            "💥 Пират наносит противнику внезапный удар!",
            "🗡️ Коварная атака пирата поражает врага!",
            "🏴‍☠️ Пират ловко обходит противника и наносит удар!"
        },
        MissMessages =
        {
            "🏴‍☠️ Пират бросается в атаку, но враг уклоняется!",
            "⚔️ Клинок пирата рассекает воздух!",
            "🗡️ Пират замахивается, но промахивается!",
            "🍾 Бутылка пролетает мимо противника!",
            "🏴‍☠️ Коварный удар пирата не достигает цели!",
            "⚔️ Противник ловко уклоняется от клинка!",
            "💥 Пират атакует слишком резко и промахивается!",
            "🗡️ Клинок проходит в нескольких сантиметрах от врага!",
            "🏴‍☠️ Пират пытается застать противника врасплох, но тот успевает отскочить!",
            "💰 Пират отвлекается на добычу и промахивается!"
        }
    };
}