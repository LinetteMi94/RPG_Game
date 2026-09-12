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
            health:56, 
            armor:20, 
            strength:22, 
            agility:13, 
            stamina:22, 
            intellect:20, 
            spirit:18), 
        IHealer
{
    protected override string ClassName =>  "Менестрель";
    protected override StatGrowth StatGrowth => new(2, 1, 2, 1, 2, 2,1);
    public int HealPower => (Intellect + Strength)/2;
    public override Resources ResourceName => Resources.Ноты;
    public override int Resource { get; set; } = 100;
    public override int MaxResource { get; set; } = 100;
    public override List<Spell> LearnedSpells { get; set; }
    public override List<Spell> SpellsToLearn { get; set; }

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