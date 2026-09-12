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
    protected override BattleMessages Messages => new()
    {
        DamageMessages =
        {
            "😈 Колдун обрушивает на врага поток демонической энергии!",
            "🔥 Тёмное пламя вспыхивает вокруг противника!",
            "🌑 Колдун выпускает из рук разрушительную энергию Тьмы!",
            "☠️ Проклятие колдуна начинает вытягивать жизненные силы врага!",
            "😈 Демоническая сила прорывается сквозь защиту противника!",
            "🔥 Адское пламя охватывает врага!",
            "🌑 Тени сгущаются вокруг противника по воле колдуна!",
            "☠️ Колдун накладывает разрушительное проклятие!",
            "🔥 Поток тёмного пламени обрушивается на противника!",
            "😈 Колдун призывает силу Бездны и поражает врага!"
        },
        MissMessages =
        {
            "😈 Демоническая энергия проходит мимо цели!",
            "🔥 Тёмное пламя вспыхивает рядом с противником!",
            "🌑 Теневой заряд рассеивается, не задев врага!",
            "☠️ Проклятие не достигает цели!",
            "😈 Колдун выпускает поток энергии, но противник успевает увернуться!",
            "🔥 Адское пламя проносится мимо противника!",
            "🌑 Тени бросаются на врага, но не успевают его настичь!",
            "☠️ Проклятие рассеивается в воздухе!",
            "🔥 Поток тёмного огня ударяет рядом с целью!",
            "😈 Колдун призывает силу Бездны, но атака проходит мимо!"
        }
    };
}