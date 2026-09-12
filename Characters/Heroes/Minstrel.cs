using System;
using RPG_Game.Characters.Monsters;
using RPG_Game.Enums;
using RPG_Game.Interfaces;
using RPG_Game.Magic;
using RPG_Game.Messages;
using RPG_Game.Progression;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет менестреля — музыканта, использующего песни и мелодии для воздействия на ход сражения.
/// Способен усиливать союзников, ослаблять противников и накладывать различные эффекты.
/// </summary>
public class Minstrel(string name) 
    : Hero(name, 
            health:58, 
            armor:15, 
            strength:12, 
            agility:22, 
            stamina:18, 
            intellect:20, 
            spirit:27), 
        IHealer
{
    protected override string ClassName =>  "Менестрель";
    protected override StatGrowth StatGrowth => new(1, 2, 1, 2, 3, 1,1);
    public int HealPower => (Intellect + Strength)/2;
    public override Resources ResourceName => Resources.Ноты;
    public override int Resource { get; set; } = 100;
    public override int MaxResource { get; set; } = 100;
   public override List<Spell> LearnedSpells { get; set; } 
        = [new("Бить голыми руками")
            {
                GetDamage = minstrel  => minstrel .Strength,
                Messages = new()
                {
                    DamageMessages =
                    {
                        "👊 Менестрель атакует врага кулаком!",
                        "💥 Менестрель наносит противнику мощный удар!",
                        "🥊 Менестрель бросается в рукопашную атаку!"
                    },
                    MissMessages =
                    {
                        "👊 Менестрель замахивается, но удар проходит мимо!",
                        "💨 Менестрель пытается ударить врага, но тот уклоняется!",
                        "🥊 Менестрель промахивается и едва не теряет равновесие!"
                    }
                }
            },
            new("Резкая нота")
                {
                    NeedResource = 10,
                    GetDamage = minstrel  => (int)Math.Round((minstrel.Intellect + minstrel.Spirit) * 0.75),
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "🎵 Резкая нота пронзает слух противника!",
                            "🎶 Менестрель извлекает ноту, от которой враг вздрагивает!",
                            "🔊 Звонкий звук обрушивается на противника!"
                        },
                        MissMessages =
                        {
                            "🎵 Резкая нота проносится мимо цели!",
                            "🎶 Звук достигает противника, но не причиняет ему вреда!",
                            "🔊 Менестрель играет ноту, но враг успевает уклониться!"
                        }
                    }
                }
            , new ("Диссонанс")
                {
                    NeedResource = 25,
                    GetDamage = minstrel  => (int)Math.Round((minstrel.Intellect + minstrel.Spirit) * 1.5),
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "🎼 Диссонанс разрывает тишину и поражает противника!",
                            "🎵 Менестрель извлекает мучительный аккорд, обрушивая его на врага!",
                            "🔊 Волна искажённого звука сотрясает противника!"
                        },
                        MissMessages =
                        {
                            "🎼 Диссонанс раздаётся вокруг противника, но не задевает его!",
                            "🎵 Менестрель берёт неверную ноту, и атака рассеивается!",
                            "🔊 Звуковая волна проходит рядом с врагом!"
                        }
                    }
                }];
    public override List<Spell> SpellsToLearn  { get; set; }
        = [new("Песнь разрушения")
                {
                    NeedResource = 45,
                    GetDamage = minstrel  => (int)Math.Round((minstrel.Intellect + minstrel.Spirit) * 2.5),
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "🎶 Менестрель исполняет Песнь разрушения, обрушивая звуковую волну на врага!",
                            "🎵 Мелодия превращается в разрушительную силу и поражает противника!",
                            "🔥 Последняя нота песни сотрясает противника с невероятной мощью!"
                        },
                        MissMessages =
                        {
                            "🎶 Песнь разрушения звучит во всей своей мощи, но враг успевает уклониться!",
                            "🎵 Разрушительная мелодия проходит мимо цели!",
                            "🔊 Менестрель завершает песнь, но звуковая волна не достигает противника!"
                        }
                    }
                }];

    private BattleMessages Messages => new()
    {
        HealMessages =
        {
            "🎵 Менестрель играет целительную мелодию, восстанавливая силы!",
            "🎶 Нежная музыка окутывает союзника и исцеляет его!",
            "💚 Целительная песнь возвращает силы!",
            "🎼 Менестрель исполняет мелодию, наполняющую тело жизненной энергией!",
            "🎵 Волшебная музыка залечивает раны!",
            "✨ Светлая мелодия восстанавливает здоровье союзника!",
            "🎻 Звуки лютни наполняют союзника жизненной силой!",
            "🎶 Песня менестреля облегчает боль и возвращает силы!",
            "💚 Гармоничная мелодия исцеляет раны!",
            "🎵 Последняя нота песни возвращает союзнику жизненные силы!"
        }
    };
    
    public void Heal()
    {
        Messages.ShowHealMessage();
        RestoreHealth(HealPower);
    }
}