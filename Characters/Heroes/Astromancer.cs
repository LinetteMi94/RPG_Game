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
        = [new("Бить голыми руками")
            {
                GetDamage = astromancer => astromancer.Strength,
                Messages = new()
                {
                    DamageMessages =
                    {
                        "👊 Астромант атакует врага кулаком!",
                        "💥 Астромант наносит противнику мощный удар!",
                        "🥊 Астромант бросается в рукопашную атаку!"
                    },
                    MissMessages =
                    {
                        "👊 Астромант замахивается, но удар проходит мимо!",
                        "💨 Астромант пытается ударить врага, но тот уклоняется!",
                        "🥊 Астромант промахивается и едва не теряет равновесие!"
                    }
                }
            },
            new("Астральный импульс")
            {
                    NeedResource = 15,
                    GetDamage = astromancer => (int)(astromancer.Intellect * 1.5),
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "🌌 Астральный импульс обрушивается на противника!",
                            "✨ Вспышка звёздной энергии поражает врага!",
                            "🌠 Астромант направляет поток астральной энергии прямо в цель!"
                        },
                        MissMessages =
                        {
                            "🌌 Астральный импульс проходит мимо цели!",
                            "✨ Вспышка астральной энергии рассеивается в воздухе!",
                            "🌠 Астромант выпускает импульс, но противник успевает уклониться!"
                        }
                    }
            },
            new ("Падающая звезда")
                {
                    NeedResource = 30,
                    GetDamage = astromancer => (int)(astromancer.Intellect*2.5),
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "☄️ Астромант обрушивает на врага падающую звезду!",
                            "🌠 Огненный небесный камень врезается в противника!",
                            "💥 Падающая звезда с грохотом поражает врага!"
                        },
                        MissMessages =
                        {
                            "☄️ Падающая звезда проносится мимо противника!",
                            "🌠 Небесный камень врезается в землю рядом с целью!",
                            "💥 Астромант вызывает падающую звезду, но враг успевает отскочить!"
                        }
                    }
                }];
    public override List<Spell> SpellsToLearn  { get; set; }
        = [new("Разрыв пространства")
                {
                    NeedResource = 50,
                    GetDamage = mage => mage.Intellect * 4,
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "🕳️ Астромант разрывает пространство вокруг противника!",
                            "🌌 Пространство искажается, обрушивая на врага астральную силу!",
                            "✨ Астромант открывает пространственный разлом прямо перед врагом!"
                        },
                        MissMessages =
                        {
                            "🕳️ Пространственный разлом закрывается, не задев противника!",
                            "🌌 Искажённое пространство рассеивается рядом с целью!",
                            "✨ Астромант открывает разлом, но противник успевает выйти из зоны поражения!"
                        }
                    }
                }];
}