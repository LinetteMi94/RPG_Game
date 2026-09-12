using System;
using RPG_Game.Characters.Monsters;
using RPG_Game.Enums;
using RPG_Game.Magic;
using RPG_Game.Messages;
using RPG_Game.Progression;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет следопыта — дальнего бойца, использующего ловкость и точность.
/// Наносит урон с расстояния и полагается на меткие атаки.
/// </summary>
public class Ranger(string name)
    : Hero(name,
        health: 55,
        armor: 16,
        strength: 18,
        agility: 30,
        stamina: 18,
        intellect: 12,
        spirit: 12)
{
    protected override string ClassName =>  "Следопыт";
    protected override StatGrowth StatGrowth => new(2, 3, 2, 1, 1, 1,1);
    public override Resources ResourceName => Resources.Концентрация;
    public override int Resource { get; set; } = 100;
    public override int MaxResource { get; set; } = 100;
    public override List<Spell> LearnedSpells { get; set; } 
        = [new("Бить голыми руками")
            {
                GetDamage = ranger => ranger.Strength,
                Messages = new()
                {
                    DamageMessages =
                    {
                        "👊 Следопыт атакует врага кулаком!",
                        "💥 Следопыт наносит противнику мощный удар!",
                        "🥊 Следопыт бросается в рукопашную атаку!"
                    },
                    MissMessages =
                    {
                        "👊 Следопыт замахивается, но удар проходит мимо!",
                        "💨 Следопыт пытается ударить врага, но тот уклоняется!",
                        "🥊 Следопыт промахивается и едва не теряет равновесие!"
                    }
                }
            },
            new("Меткий выстрел")
                {
                    NeedResource = 15,
                    GetDamage = ranger => (int)Math.Round(ranger.Agility * 1.5),
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "🏹 Следопыт выпускает стрелу точно в цель!",
                            "🎯 Меткий выстрел поражает противника!",
                            "🏹 Стрела следопыта находит уязвимое место врага!"
                        },
                        MissMessages =
                        {
                            "🏹 Стрела пролетает мимо цели!",
                            "🎯 Следопыт выпускает стрелу, но противник успевает уклониться!",
                            "💨 Стрела рассекает воздух рядом с врагом!"
                        }
                    }
                }
            , new ("Охотничий выпад")
                {
                    NeedResource = 30,
                    GetDamage = ranger => (int)Math.Round((ranger.Agility + ranger.Strength) * 1.5),
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "🗡️ Следопыт стремительно бросается вперёд и наносит удар!",
                            "🏹 Следопыт сокращает дистанцию и поражает врага клинком!",
                            "⚔️ Быстрый выпад следопыта пробивает защиту противника!"
                        },
                        MissMessages =
                        {
                            "🗡️ Следопыт бросается в атаку, но противник успевает отскочить!",
                            "💨 Клинок проходит в нескольких сантиметрах от врага!",
                            "⚔️ Следопыт пытается нанести выпад, но промахивается!"
                        }
                    }
                }];
    public override List<Spell> SpellsToLearn  { get; set; }
        = [new("Залп стрел")
                {
                    NeedResource = 50,
                    GetDamage = ranger => (int)Math.Round(ranger.Agility * 3.5),
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "🏹 Следопыт выпускает целый залп стрел в противника!",
                            "💥 Несколько стрел одновременно поражают врага!",
                            "🏹 Стрелы обрушиваются на противника одна за другой!"
                        },
                        MissMessages =
                        {
                            "🏹 Следопыт выпускает залп, но противник успевает уклониться!",
                            "💨 Стрелы пролетают мимо цели одна за другой!",
                            "🏹 Весь залп рассекает воздух, не задев противника!"
                        }
                    }
                }];
}