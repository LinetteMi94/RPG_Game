using System;
using RPG_Game.Audio;
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
    protected override string NoResourceMessage => "Недостаточно маны!";
    public override int Resource { get; set; } = 100;
    public override int MaxResource { get; set; } = 100;
    public override List<Spell> LearnedSpells { get; set; } 
        = [new("Бить голыми руками")
            {
                GetDamage = warlock => warlock.Strength,
                Messages = new()
                {
                    DamageMessages =
                    {
                        "👊 Колдун атакует врага кулаком!",
                        "💥 Колдун наносит противнику мощный удар!",
                        "🥊 Колдун бросается в рукопашную атаку!"
                    },
                    MissMessages =
                    {
                        "👊 Колдун замахивается, но удар проходит мимо!",
                        "💨 Колдун пытается ударить врага, но тот уклоняется!",
                        "🥊 Колдун промахивается и едва не теряет равновесие!"
                    }
                },
                Sound = new SpellSound("Sounds/Spells/Punch_Hit.mp3", "Sounds/Spells/Punch_Cast.mp3")
            },
            new("Порча")
                {
                    NeedResource = 15,
                    GetDamage = warlock => (int)Math.Round(warlock.Intellect * 1.5),
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "🖤 Тёмная энергия окутывает противника, причиняя ему боль!",
                            "☠️ Колдун накладывает на врага зловещее проклятие!",
                            "🌑 Тёмная магия впивается в противника, вытягивая его силы!"
                        },
                        MissMessages =
                        {
                            "🖤 Тёмная энергия рассеивается, не достигнув цели!",
                            "☠️ Проклятие Колдуна не находит свою жертву!",
                            "🌑 Тёмная магия проходит мимо противника!"
                        }
                    },
                    Sound = new SpellSound("Sounds/Spells/Corruption_Impact.mp3", "Sounds/Spells/Corruption_Cast.mp3")
                }
            , new ("Теневой удар")
                {
                    NeedResource = 30,
                    GetDamage = warlock => (int)Math.Round(warlock.Intellect * 2.5),
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "🌑 Тень обрушивается на противника с сокрушительной силой!",
                            "🖤 Колдун выпускает сгусток тёмной энергии прямо во врага!",
                            "☠️ Теневой удар поражает противника, погружая его во тьму!"
                        },
                        MissMessages =
                        {
                            "🌑 Теневой удар проходит мимо противника!",
                            "🖤 Сгусток тёмной энергии ударяет рядом с целью!",
                            "☠️ Колдун выпускает теневую силу, но враг успевает уклониться!"
                        }
                    },
                    Sound = new SpellSound("Sounds/Spells/Shadow_Strike_Impact.mp3", "Sounds/Spells/Shadow_Strike_Cast.mp3")
                }];
    public override List<Spell> SpellsToLearn  { get; set; }
        = [new("Проклятие бездны")
                {
                    NeedResource = 50,
                    GetDamage = warlock => warlock.Intellect * 4,
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "🕳️ Бездны раскрывается перед противником, поглощая его своей силой!",
                            "🌑 Колдун призывает силу Бездны, обрушивая её на врага!",
                            "☠️ Проклятие Бездны охватывает противника и разрывает его защиту!"
                        },
                        MissMessages =
                        {
                            "🕳️ Бездны раскрывается рядом с целью, но не задевает её!",
                            "🌑 Сила Бездны рассеивается, не достигнув противника!",
                            "☠️ Колдун призывает Бездну, но враг успевает вырваться из зоны поражения!"
                        }
                    },
                    Sound = new SpellSound("Sounds/Spells/Curse_Of_The_Abyss_Impact.mp3", "Sounds/Spells/Curse_Of_The_Abyss_Cast.mp3")
                }];
}