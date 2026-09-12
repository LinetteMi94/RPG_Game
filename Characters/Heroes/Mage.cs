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
        health:54, 
        armor:20,
        strength:12, 
        agility:20, 
        stamina:20, 
        intellect:24, 
        spirit:22)
{
   
    public override Resources ResourceName => Resources.Мана;
    public override int Resource { get; set; } = 100;
    public override int MaxResource { get; set; } = 100;
    protected override StatGrowth StatGrowth => new (1, 1, 1, 2, 2, 0,3);
    protected override string ClassName =>  "Маг";
    protected override int Damage { get; set; }
    public override List<Spell> LearnedSpells { get; set; } 
        = [new("Ледяная стрела")
                {
                    NeedResource = 20,
                    GetDamage = mage => mage.Intellect * 2
                }
            , new ("Огненный шар")
                {
                    NeedResource = 30,
                    GetDamage = mage => (int)(mage.Intellect*2.5)
                }];
    public override List<Spell> SpellsToLearn  { get; set; }
        = [new("Электрический разряд")
                {
                    NeedResource = 40,
                    GetDamage = mage => mage.Intellect * 3
                }];
    protected override BattleMessages Messages => new()
    {
        DamageMessages =
        {
            "🔥 Маг обрушивает на врага поток огненной энергии!",
            "❄️ Ледяная вспышка поражает противника!",
            "💧 Маг направляет мощный поток воды на врага!",
            "✨ Магическая энергия пронзает противника!",
            "🔥 Огненный заряд врезается в противника!",
            "❄️ Ледяные осколки срываются с рук мага и поражают врага!",
            "💦 Водный поток обрушивается на противника!",
            "🔮 Маг выпускает разрушительный заряд энергии!",
            "❄️ Волна холода окутывает врага!",
            "🔥 Вспышка пламени охватывает противника!"
        },
        MissMessages =
        {
            "🔥 Огненный заряд проносится мимо цели!",
            "❄️ Ледяные осколки разбиваются рядом с противником!",
            "💧 Поток воды проходит мимо цели!",
            "✨ Магическая энергия рассеивается, не задев противника!",
            "🔥 Огненная вспышка ударяет рядом с врагом!",
            "❄️ Ледяное заклинание не достигает цели!",
            "💦 Водный поток проходит в стороне от противника!",
            "🔮 Магический заряд рассеивается в воздухе!",
            "❄️ Волна холода проходит мимо врага!",
            "🔥 Пламя вспыхивает рядом с противником, но не задевает его!"
        }
    };
    
    public override void ShowAbilities(int choose, Monster target)
    {
        Spell? spellForAttack = null;
        switch (choose)
        {
            case 1:
                spellForAttack = new Spell(null) {GetDamage =  mage => mage.Strength};
                break;
            case 2:
                spellForAttack = LearnedSpells.FirstOrDefault(spell => spell.SpellName == "Ледяная стрела");
                break;
            case 3:
                spellForAttack = LearnedSpells.FirstOrDefault(spell => spell.SpellName == "Огненный шар");
                break;
            case 4:
                spellForAttack = LearnedSpells.FirstOrDefault(spell => spell.SpellName == "Электрический разряд");
                break;
        }
        Attack(target, spellForAttack);
    }

    protected override void Attack(Monster target, Spell? spell, bool ignoreArmor = false)
    {
        if (Resource >= spell.NeedResource)
        {
            Resource -= spell.NeedResource;
            base.Attack(target,spell);
        }
        else Console.WriteLine("Недостаточно маны!");
    }
}