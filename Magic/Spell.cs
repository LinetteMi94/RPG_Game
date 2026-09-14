using RPG_Game.Audio;
using RPG_Game.Characters.Heroes;
using RPG_Game.Characters.Monsters;
using RPG_Game.Messages;

namespace RPG_Game.Magic;

public class Spell(string spellName)
{
    public string SpellName { get; } = spellName;
    public int NeedResource { get; init; }
    public int GiveResource { get; init; }
    public Func<Hero, int> GetDamage { get; set; }
    public BattleMessages Messages { get; set; } 
    
    public SpellSound Sound { get; set; } 
}