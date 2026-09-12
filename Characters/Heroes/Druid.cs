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
    public override List<Spell> SpellsToLearn { get; set; }
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