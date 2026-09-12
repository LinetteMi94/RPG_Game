using RPG_Game.Characters.Heroes;
using RPG_Game.Characters.Monsters;

namespace RPG_Game.Magic;

public class Spell(string spellName)
{
    public string SpellName { get; set; } = spellName;
    public int NeedResource { get; set; }
    public Func<Hero, int> GetDamage { get; set; }
}