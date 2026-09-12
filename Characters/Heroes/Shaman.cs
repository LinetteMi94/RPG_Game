using System;
using RPG_Game.Characters.Monsters;
using RPG_Game.Enums;
using RPG_Game.Interfaces;
using RPG_Game.Magic;
using RPG_Game.Messages;
using RPG_Game.Progression;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет шамана — повелителя стихий, использующего силу природы.
/// Может применять магические атаки и восстанавливать здоровье союзников.
/// </summary>
public class Shaman(string name) 
    : Hero(name, 
            health:62,
            armor:18, 
            strength:13, 
            agility:18, 
            stamina:21, 
            intellect:22, 
            spirit:29), 
        IHealer
{
    protected override StatGrowth StatGrowth => new(1, 1, 2, 2, 3, 1,2);
    protected override string ClassName =>  "Шаман";
    public override Resources ResourceName => Resources.Мана;
    public override int Resource { get; set; } = 100;
    public override int MaxResource { get; set; } = 100;
    public override List<Spell> LearnedSpells { get; set; } 
        = [new("Бить голыми руками")
            {
                GetDamage = shaman => shaman.Strength,
                Messages = new()
                {
                    DamageMessages =
                    {
                        "👊 Шаман атакует врага кулаком!",
                        "💥 Шаман наносит противнику мощный удар!",
                        "🥊 Шаман бросается в рукопашную атаку!"
                    },
                    MissMessages =
                    {
                        "👊 Шаман замахивается, но удар проходит мимо!",
                        "💨 Шаман пытается ударить врага, но тот уклоняется!",
                        "🥊 Шаман промахивается и едва не теряет равновесие!"
                    }
                }
            },
            new("Духовное пламя")
                {
                    NeedResource = 15,
                    GetDamage = shaman => (int)Math.Round(shaman.Spirit * 1.5),
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "🔥 Шаман призывает духовное пламя, обрушивая его на врага!",
                            "👻 Огни духов вспыхивают вокруг противника!",
                            "🔥 Духовное пламя поражает врага потусторонним жаром!"
                        },
                        MissMessages =
                        {
                            "🔥 Духовное пламя проходит мимо цели!",
                            "👻 Духовный огонь вспыхивает рядом с противником, но не задевает его!",
                            "🔥 Шаман призывает пламя, но враг успевает уклониться!"
                        }
                    }
                }
            , new ("Гнев духов")
                {
                    NeedResource = 30,
                    GetDamage = shaman => (int)Math.Round((shaman.Spirit + shaman.Intellect) * 1.5),
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "👻 Духи обрушивают свой гнев на противника!",
                            "⚡ Разгневанные духи атакуют врага со всех сторон!",
                            "🌪️ Шаман призывает духов, и их ярость поражает противника!"
                        },
                        MissMessages =
                        {
                            "👻 Духи атакуют, но противник успевает уклониться!",
                            "🌪️ Гнев духов проносится рядом с целью!",
                            "⚡ Призванные духи не успевают настичь противника!"
                        }
                    }
                }];
    
    public override List<Spell> SpellsToLearn  { get; set; }
        = [new("Гнев небес")
                {
                    NeedResource = 50,
                    GetDamage = shaman => (int)Math.Round((shaman.Spirit + shaman.Intellect) * 2.5),
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "🌩️ Шаман призывает силу небес, обрушивая молнию на врага!",
                            "⚡ Небесный гром поражает противника!",
                            "🌩️ Молния с грохотом обрушивается на врага по воле шамана!"
                        },
                        MissMessages =
                        {
                            "🌩️ Молния ударяет рядом с противником!",
                            "⚡ Гром раскатывается над полем боя, но враг избегает удара!",
                            "🌩️ Шаман призывает небесную силу, но молния не достигает цели!"
                        }
                    }
                }];
    
    public int HealPower => (Intellect + Spirit)/2;

    private BattleMessages Messages => new()
    {
        HealMessages =
        {
            "⚡ Шаман призывает духов, чтобы восстановить силы!",
            "👻 Духи предков исцеляют раны шамана!",
            "🌿 Шаман направляет поток природной энергии!",
            "💧 Дух воды восстанавливает здоровье!",
            "⚡ Энергия стихий возвращает силы!",
            "👻 Духи окружают шамана и помогают ему восстановиться!",
            "🌊 Жизненная энергия воды исцеляет раны!",
            "⚡ Шаман получает поддержку от духов природы!",
            "🌪️ Сила стихий наполняет тело энергией!",
            "👻 Предки отвечают на зов шамана и даруют исцеление!"
        }
    };

    public void Heal()
    {
        Messages.ShowHealMessage();
        RestoreHealth(HealPower);
    }
}