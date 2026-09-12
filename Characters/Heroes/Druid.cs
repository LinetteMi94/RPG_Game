using System;
using RPG_Game.Characters.Monsters;
using RPG_Game.Enums;
using RPG_Game.Interfaces;
using RPG_Game.Magic;
using RPG_Game.Messages;
using RPG_Game.Progression;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет друида — защитника природы, владеющего силами жизни и зверей.
/// Может использовать природную магию для атаки и восстановления здоровья.
/// </summary>
public class Druid(string name) 
    : Hero(name, 
            health:60, 
            armor:15, 
            strength:10, 
            agility:17, 
            stamina:20, 
            intellect:25, 
            spirit:30), 
        IHealer
{
    protected override string ClassName => "Друид";
    protected override StatGrowth StatGrowth => new(1, 1, 2, 3, 3, 1,2);
    public override Resources ResourceName => Resources.Мана;
    public override int Resource { get; set; } = 100;
    public override int MaxResource { get; set; } = 100;
    public override List<Spell> LearnedSpells { get; set; } 
        = [new("Бить голыми руками")
            {
                GetDamage = druid => druid.Strength,
                Messages = new()
                {
                    DamageMessages =
                    {
                        "👊 Друид атакует врага кулаком!",
                        "💥 Друид наносит противнику мощный удар!",
                        "🥊 Друид бросается в рукопашную атаку!"
                    },
                    MissMessages =
                    {
                        "👊 Друид замахивается, но удар проходит мимо!",
                        "💨 Друид пытается ударить врага, но тот уклоняется!",
                        "🥊 Друид промахивается и едва не теряет равновесие!"
                    }
                }
            },
            new("Терновый хлыст")
            {
                    NeedResource = 15,
                    GetDamage = druid => (int)(druid.Intellect*1.5),
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "🌿 Терновый хлыст обвивается вокруг противника и наносит удар!",
                            "🍃 Друид призывает лозы, и острые шипы впиваются во врага!",
                            "🌱 Из земли вырываются колючие ветви и атакуют противника!"
                        },
                        MissMessages =
                        {
                            "🌿 Терновый хлыст не достигает противника!",
                            "🍃 Лозы хлещут воздух, но враг успевает отскочить!",
                            "🌱 Колючие ветви вырываются из земли, но проходят мимо цели!"
                        }
                    }
            },
            new ("Гнев природы")
                {
                    NeedResource = 30,
                    GetDamage = druid => (int)(druid.Intellect*2.5),
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "🌪️ Друид призывает силу природы, обрушивая её на врага!",
                            "🌳 Земля содрогается, а корни атакуют противника со всех сторон!",
                            "🍃 Буря листьев и ветвей обрушивается на врага!"
                        },
                        MissMessages =
                        {
                            "🌪️ Гнев природы проносится мимо противника!",
                            "🌳 Корни вырываются из земли, но враг успевает уклониться!",
                            "🍃 Буря поднимается вокруг цели, но не причиняет ей вреда!"
                        }
                    }
                }];
    
    public override List<Spell> SpellsToLearn  { get; set; }
        = [new("Пробуждение древнего леса")
                {
                    NeedResource = 50,
                    GetDamage = druid => druid.Intellect * 4,
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "🌳 Древний лес пробуждается и обрушивает свою силу на противника!",
                            "🌿 Корни и ветви древних деревьев сметают врага!",
                            "🍂 Сила древнего леса обрушивается на противника со всей мощью!"
                        },
                        MissMessages =
                        {
                            "🌳 Древний лес пробуждается, но противник успевает уклониться!",
                            "🌿 Корни тянутся к врагу, но смыкаются в пустоте!",
                            "🍂 Ветви обрушиваются рядом с целью, не задев её!"
                        }
                    }
                }];
    
    public int HealPower => (Intellect + Spirit)/2;


    private BattleMessages Messages => new()
    {
        HealMessages =
        {
            "🌿 Друид призывает силу природы и восстанавливает здоровье!",
            "🍃 Живительная энергия леса исцеляет раны!",
            "🌱 Друид направляет поток природной силы, возвращая здоровье!",
            "🌿 Целебная энергия природы окутывает героя!",
            "🍀 Сила земли и растений помогает восстановить силы!",
            "🌳 Друид обращается к духам природы за помощью!",
            "🌱 Природная магия закрывает раны и возвращает энергию!",
            "🍃 Лесной поток жизненной силы исцеляет героя!",
            "🌿 Древняя сила природы восстанавливает здоровье!"
        }
    };
    
    public void Heal()
    {
        Messages.ShowHealMessage();
        RestoreHealth(HealPower);
    }
}