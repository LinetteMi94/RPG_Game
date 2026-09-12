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
            health:55,
            armor:20, 
            strength:16, 
            agility:21, 
            stamina:21, 
            intellect:21, 
            spirit:20), 
        IHealer
{
    protected override StatGrowth StatGrowth => new(2, 1, 2, 2, 1, 1,2);
    protected override string ClassName =>  "Шаман";
    public override Resources ResourceName => Resources.Мана;
    public override int Resource { get; set; } = 100;
    public override int MaxResource { get; set; } = 100;
    public override List<Spell> LearnedSpells { get; set; }
    public override List<Spell> SpellsToLearn { get; set; }
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