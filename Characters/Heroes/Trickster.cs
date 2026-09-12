using RPG_Game.Enums;
using RPG_Game.Magic;
using RPG_Game.Progression;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет циркача — ловкого и непредсказуемого бойца, использующего акробатику,
/// трюки и хитрые приёмы для нанесения урона.
/// Основывается на ловкости и обладает запасом адреналина.
/// </summary>
public class Trickster(string name) 
    : Hero(name, 
        health:58, 
        armor:14,
        strength:14, 
        agility:32, 
        stamina:18, 
        intellect:16, 
        spirit:22)
{
    protected override string ClassName =>  "Циркач";
    public override Resources ResourceName => Resources.Адреналин;
    protected override StatGrowth StatGrowth => new (1, 4, 2, 1, 2, 1,2);
    public override int Resource { get; set; } = 100;
    public override int MaxResource { get; set; } = 100;
    public override List<Spell> LearnedSpells { get; set; } 
        = [new("Бить голыми руками")
            {
                GetDamage = trickster => trickster.Strength,
                Messages = new()
                {
                    DamageMessages =
                    {
                        "👊 Циркач атакует врага кулаком!",
                        "💥 Циркач наносит противнику мощный удар!",
                        "🥊 Циркач бросается в рукопашную атаку!"
                    },
                    MissMessages =
                    {
                        "👊 Циркач замахивается, но удар проходит мимо!",
                        "💨 Циркач пытается ударить врага, но тот уклоняется!",
                        "🥊 Циркач промахивается и едва не теряет равновесие!"
                    }
                }
            },
            new("Жонглирование клинками")
                {
                    NeedResource = 15,
                    GetDamage = trickster => (int)Math.Round(trickster.Agility * 1.5),
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "🔪 Циркач ловко жонглирует клинками и поражает противника!",
                            "🎪 Несколько клинков одновременно устремляются в сторону врага!",
                            "✨ Циркач превращает жонглирование в опасную атаку!"
                        },
                        MissMessages =
                        {
                            "🔪 Клинок Циркача пролетает мимо противника!",
                            "🎪 Циркач жонглирует клинками, но ни один не достигает цели!",
                            "💨 Клинки рассекают воздух рядом с врагом!"
                        }
                    }
                }
            , new ("Акробатический выпад")
                {
                    NeedResource = 30,
                    GetDamage = trickster => (int)Math.Round((trickster.Agility + trickster.Strength) * 1.5), 
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "🤸 Циркач делает сальто и обрушивает удар на противника!",
                            "🎪 Акробатический трюк неожиданно превращается в сокрушительную атаку!",
                            "⚔️ Циркач стремительно пролетает над противником и наносит удар!"
                        },
                        MissMessages =
                        {
                            "🤸 Циркач делает сальто, но противник успевает уклониться!",
                            "🎪 Акробатический выпад проходит мимо цели!",
                            "💨 Циркач приземляется после трюка, не задев противника!"
                        }
                    }
                }];
    public override List<Spell> SpellsToLearn  { get; set; }
        = [new("Смертельное представление")
                {
                    NeedResource = 50,
                    GetDamage = trickster => trickster.Agility * 4,
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "🎪 Циркач превращает поле боя в арену и обрушивает на врага шквал ударов!",
                            "🔥 Невероятная серия трюков заканчивается сокрушительным ударом по противнику!",
                            "🤹 Циркач исполняет смертельный номер, поражая врага со всех сторон!"
                        },
                        MissMessages =
                        {
                            "🎪 Циркач устраивает невероятное представление, но противник не попадается в ловушку!",
                            "🔥 Серия акробатических трюков не достигает цели!",
                            "🤹 Смертельный номер заканчивается эффектным приземлением, но враг остаётся невредим!"
                        }
                    }
                }];
    
}