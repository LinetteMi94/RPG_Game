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
        health: 60,
        armor: 20,
        strength: 23,
        agility: 27,
        stamina: 20,
        intellect: 8,
        spirit: 10)
{
    protected override string ClassName =>  "Пират";
    protected override StatGrowth StatGrowth => new(2, 3, 2, 1, 1, 1,0);
    public override Resources ResourceName => Resources.Азарт;
    public override int Resource { get; set; } = 0;
    public override int MaxResource { get; set; } = 100;
    public override List<Spell> LearnedSpells { get; set; } 
        = [new("Бить голыми руками")
            {
                GetDamage = pirate => pirate.Strength,
                Messages = new()
                {
                    DamageMessages =
                    {
                        "👊 Пират атакует врага кулаком!",
                        "💥 Пират наносит противнику мощный удар!",
                        "🥊 Пират бросается в рукопашную атаку!"
                    },
                    MissMessages =
                    {
                        "👊 Пират замахивается, но удар проходит мимо!",
                        "💨 Пират пытается ударить врага, но тот уклоняется!",
                        "🥊 Пират промахивается и едва не теряет равновесие!"
                    }
                }
            },
            new("Коварный удар")
                {
                    NeedResource = 10,
                    GetDamage = pirate => (int)Math.Round((pirate.Strength + pirate.Agility) * 0.75),
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "🏴‍☠️ Пират наносит врагу коварный удар!",
                            "🗡️ Пират ловко обходит защиту противника и наносит удар!",
                            "⚔️ Клинок пирата молниеносно находит брешь в защите врага!"
                        },
                        MissMessages =
                        {
                            "🏴‍☠️ Пират пытается застать врага врасплох, но тот уклоняется!",
                            "🗡️ Клинок пирата рассекает воздух!",
                            "⚔️ Пират наносит коварный удар, но промахивается!"
                        }
                    }
                }
            , new ("Бутылочный разгром")
                {
                    NeedResource = 20,
                    GetDamage = pirate => (int)(pirate.Intellect*1.5),
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "🍾 Пират разбивает бутылку о голову противника!",
                            "🏴‍☠️ Пират с размаху обрушивает бутылку на врага!",
                            "💥 Стекло разлетается, когда бутылка пирата встречается с противником!"
                        },
                        MissMessages =
                        {
                            "🍾 Пират замахивается бутылкой, но промахивается!",
                            "💨 Бутылка пролетает мимо головы противника!",
                            "🏴‍☠️ Пират пытается огреть врага бутылкой, но тот успевает отскочить!"
                        }
                    }
                }];
    public override List<Spell> SpellsToLearn  { get; set; }
        = [new("Капитанский натиск")
                {
                    NeedResource = 45,
                    GetDamage = pirate => (int)Math.Round((pirate.Strength + pirate.Agility) * 2.5),
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "🏴‍☠️ Пират бросается в яростную атаку, обрушивая клинок на врага!",
                            "⚔️ Капитанский натиск сметает защиту противника!",
                            "💥 Пират идёт ва-банк и наносит сокрушительный удар!"
                        },
                        MissMessages =
                        {
                            "🏴‍☠️ Пират бросается в атаку, но враг успевает увернуться!",
                            "⚔️ Клинок с грохотом ударяет мимо цели!",
                            "💨 Пират идёт ва-банк, но противник выходит из-под удара!" 
                        }
                    }
                }];
}