using RPG_Game.Interfaces;
using RPG_Game.Characters.Monsters;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет друида — защитника природы, владеющего силами жизни и зверей.
/// Может использовать природную магию для атаки и восстановления здоровья.
/// </summary>
public class Druid(string name) 
    : Hero(name, 
            health:55, 
            mana: 130, 
            armor:20, 
            strength:15, 
            agility:22, 
            stamina:21, 
            intellect:20, 
            spirit:21,
            new StatGrowth(1,2,2,2,1,1)), 
        IHealer<Hero>
{
    protected override string ClassName => "Друид";
    public override int Damage => Intellect+Agility;
    public int HealPower => (Intellect + Spirit)/2;
    
    public BattleMessages Messages = new BattleMessages
    {
        DamageMessages =
        {
            "🌿 Друид призывает силу природы и обрушивает поток энергии на врага!",
            "🍃 Древние корни пробиваются из земли и оплетают противника!",
            "🌱 Друид направляет ярость леса против врага!",
            "🐺 Дух зверя вселяется в друида, усиливая его удар!",
            "🌳 Сила древнего леса отвечает на зов друида!",
            "🍂 Друид выпускает вихрь острых листьев!",
            "🌿 Природная энергия вспыхивает вокруг рук друида!",
            "🦌 Духи леса атакуют врага по приказу друида!",
            "🌲 Друид заставляет землю содрогнуться под ногами противника!",
            "✨ Друид направляет поток жизненной силы, превращая её в оружие!"
        },
        MissMessages =
        {
            "🛡️ Атака друида была остановлена бронёй!",
        }
    };
    
    
    public void Heal() => RestoreHealth(HealPower);
    
    public void Heal(Hero hero) => hero.RestoreHealth(HealPower);
    
    public override void Attack(Monster target)
    {
        if (IsAlive)
        {
            target.TakeDamage(Damage);
            Messages.ShowDamageMessage(Messages.DamageMessages);
            Console.WriteLine($"{Name} наносит {Damage - target.Armor} урона {target.Name}!");
            Console.WriteLine($"{target.Name}, здоровье {target.Health}/{target.MaxHealth}!");
        }
    }
}