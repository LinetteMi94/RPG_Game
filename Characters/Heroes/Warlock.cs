using RPG_Game.Characters.Monsters;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет чернокнижника — мага тёмных искусств, использующего силу Бездны.
/// Наносит магический урон, игнорирующий броню противника.
/// </summary>
public class Warlock(string name) 
    : Hero(name, 
        health:55, 
        mana: 180, 
        armor:20, 
        strength:11, 
        agility:18, 
        stamina:21, 
        intellect:24, 
        spirit:22,
        new StatGrowth(1,1,1,2,2,0))
{
    protected override string ClassName =>  "Чернокнижник";
    
    public override int Damage => (int)Math.Round(Intellect*2.5 + Spirit*0.5);
    
    public override void Attack(Monster target)
    {
        if (IsAlive)
        {
            Console.WriteLine($"{Name} призывает силы Бездны! Нанесено {Damage} урона!");
            target.TakeDamage(Damage, true);
        }
    }

    protected virtual void OnLevelUp()
    {
        
    }
}