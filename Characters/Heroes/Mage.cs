using System;
using RPG_Game.Audio;
using RPG_Game.Characters.Monsters;
using RPG_Game.Enums;
using RPG_Game.Messages;
using RPG_Game.Progression;
using RPG_Game.Interfaces;
using RPG_Game.Magic;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет мага — заклинателя, использующего магическую силу для нанесения урона.
/// Основывается на интеллекте и обладает большим запасом маны.
/// </summary>
public class Mage(string name) 
    : Hero(name, 
        health:50, 
        armor:12,
        strength:8, 
        agility:16, 
        stamina:16, 
        intellect:32, 
        spirit:22)
{
   
    public override Resources ResourceName => Resources.Мана;
    public override int Resource { get; set; } = 100;
    public override int MaxResource { get; set; } = 100;
    protected override StatGrowth StatGrowth => new (1, 1, 1, 4, 2, 1,3);
    protected internal override string ClassName =>  "Маг";
    protected override string NoResourceMessage => "Недостаточно маны!";
    public override List<Spell> LearnedSpells { get; set; } 
        = [new("Бить голыми руками")
            {
                GetDamage = mage => mage.Strength,
                Messages = new()
                {
                    DamageMessages =
                    {
                        "👊 Маг атакует врага кулаком!",
                        "💥 Маг наносит противнику мощный удар!",
                        "🥊 Маг бросается в рукопашную атаку!"
                    },
                    MissMessages =
                    {
                        "👊 Маг замахивается, но удар проходит мимо!",
                        "💨 Маг пытается ударить врага, но тот уклоняется!",
                        "🥊 Маг промахивается и едва не теряет равновесие!"
                    }
                },
                Sound = new SpellSound("Sounds/Spells/Punch_Hit.mp3", "Sounds/Spells/Punch_Cast.mp3")
            },
            new("Ледяная стрела")
                {
                    NeedResource = 15,
                    GetDamage = mage => mage.Intellect * 2,
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "❄️ Ледяная стрела пронзает противника!",
                            "🧊 Маг поражает врага острым ледяным снарядом!",
                            "❄️ Морозная стрела сковывает врага холодом!"
                        },
                        MissMessages =
                        {
                            "❄️ Ледяная стрела проносится мимо цели!",
                            "🧊 Ледяной снаряд разбивается о землю!",
                            "❄️ Маг выпускает стрелу, но противник успевает уклониться!"
                        }
                    },
                    Sound = new SpellSound("Sounds/Spells/Ice_Arrow_Impact.mp3", "Sounds/Spells/Ice_Arrow_Cast.mp3")
                }
            , new ("Огненный шар")
                {
                    NeedResource = 20,
                    GetDamage = mage => (int)(mage.Intellect*1.5),
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "🔥 Огненный шар обрушивается на противника!",
                            "💥 Пылающий снаряд поражает врага!",
                            "🔥 Маг запускает огненный шар прямо в цель!"
                        },
                        MissMessages =
                        {
                            "🔥 Огненный шар пролетает мимо противника!",
                            "💨 Пылающий снаряд взрывается рядом с целью!",
                            "🔥 Маг промахивается, и огненный шар исчезает в воздухе!"
                        }
                    },
                    Sound = new SpellSound("Sounds/Spells/Fireball_Impact.mp3", "Sounds/Spells/Fireball_Cast.mp3")
                }];
    public override List<Spell> SpellsToLearn  { get; set; }
        = [new("Электрический разряд")
                {
                    NeedResource = 45,
                    GetDamage = mage => (int)(mage.Intellect * 3.5),
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "⚡ Электрический разряд поражает противника!",
                            "⚡ Молния пронзает врага вспышкой энергии!",
                            "💥 Маг обрушивает на цель мощный электрический удар!"
                        },
                        MissMessages =
                        {
                            "⚡ Электрический разряд проходит мимо цели!",
                            "💨 Молния ударяет в землю рядом с противником!",
                            "⚡ Маг выпускает разряд, но враг успевает отскочить!"
                        }
                    },
                    Sound = new SpellSound("Sounds/Spells/Electric_Discharge_Impact.mp3", "Sounds/Spells/Electric_Discharge_Cast.mp3")
                }];
}