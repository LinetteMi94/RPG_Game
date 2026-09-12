using System;
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
    protected override string ClassName =>  "Маг";
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
                }
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
                    }
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
                    }
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
                    }
                }];
    
    protected internal override void Attack(Monster target, Spell? spell, bool ignoreArmor = false)
    {
        if (Resource >= spell.NeedResource)
        {
            Resource -= spell.NeedResource;
            base.Attack(target,spell);
        }
        else Console.WriteLine("Недостаточно маны!");
    }
}