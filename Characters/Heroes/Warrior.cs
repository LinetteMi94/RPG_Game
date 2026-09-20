using RPG_Game.Audio;
using RPG_Game.Characters.Monsters;
using RPG_Game.Enums;
using RPG_Game.Magic;
using RPG_Game.Messages;
using RPG_Game.Progression;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет воина — мастера ближнего боя с высокой силой, бронёй и выносливостью.
/// Наносит мощные физические атаки и способен выдерживать большой урон.
/// </summary>
public class Warrior(string name)
    : Hero(name, 
        health:70, 
        armor:30, 
        strength:25, 
        agility:15, 
        stamina:28, 
        intellect:8, 
        spirit:12)
{
    protected override StatGrowth StatGrowth => new(3, 1, 3, 1, 1, 2,0);
    protected internal override string ClassName =>  "Воин";
    public override Resources ResourceName => Resources.Ярость;
    protected override string NoResourceMessage => "Недостаточно ярости!";
    public override int Resource { get; set; } = 0;
    public override int MaxResource { get; set; } = 100;
    public override List<Spell> LearnedSpells { get; set; } 
        = [new("Бить голыми руками")
            {
                GiveResource = 15,
                GetDamage = warrior => warrior.Strength,
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
            new("Сильный удар")
                {
                    GiveResource = 25,
                    GetDamage =warrior => warrior.Strength * 2,
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "⚔️ Воин обрушивает тяжёлый удар на противника!",
                            "💥 Мощный удар воина пробивает защиту врага!",
                            "🗡️ Воин с силой обрушивает оружие на противника!"
                        },
                        MissMessages =
                        {
                            "⚔️ Воин замахивается, но противник успевает уклониться!",
                            "💨 Тяжёлый удар воина рассекает воздух!",
                            "🗡️ Воин наносит удар, но промахивается!"
                        }
                    },
                    Sound = new SpellSound("Sounds/Spells/Warrior/Powerful_Strike_Impact.mp3", "Sounds/Spells/Warrior/Powerful_Strike_Cast.mp3")
                }
            , new ("Сокрушительный выпад")
                {
                    NeedResource = 30,
                    GetDamage = warrior => warrior.Strength * 3,
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "⚔️ Воин стремительно бросается вперёд и наносит сокрушительный выпад!",
                            "💥 Клинок воина с силой врезается в противника!",
                            "🛡️ Воин пробивает защиту врага мощным выпадом!"
                        },
                        MissMessages =
                        {
                            "⚔️ Воин бросается вперёд, но противник успевает отскочить!",
                            "💨 Сокрушительный выпад проходит мимо цели!",
                            "🗡️ Воин пытается пробить защиту врага, но промахивается!"
                        }
                    },
                    Sound = new SpellSound("Sounds/Spells/Warrior/Devastating_Lunge_Impact.mp3", "Sounds/Spells/Warrior/Devastating_Lunge_Cast.mp3")
                }];
    public override List<Spell> SpellsToLearn  { get; set; }
        = [new("Размашистый удар")
                {
                    NeedResource = 50,
                    GetDamage = warrior => warrior.Strength * 4,
                    Messages = new()
                    {
                        DamageMessages =
                        {
                            "💥 Воин обрушивает на противника размашистый удар всей своей силой!",
                            "⚔️ Мощнейший взмах оружия сметает противника!",
                            "🔥 Воин собирает всю силу и наносит сокрушительный удар!"
                        },
                        MissMessages =
                        {
                            "💥 Размашистый удар воина проходит мимо противника!",
                            "⚔️ Воин вкладывает всю силу в удар, но враг успевает уклониться!",
                            "💨 Оружие с грохотом рассекает воздух рядом с противником!"
                        }
                    },
                    Sound = new SpellSound("Sounds/Spells/Warrior/Sweeping_Strike_Impact.mp3", "Sounds/Spells/Warrior/Sweeping_Strike_Cast.mp3")
                }];
    
}