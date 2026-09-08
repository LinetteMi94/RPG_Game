using RPG_Game.Characters.Monsters;
using RPG_Game.Messages;
using RPG_Game.Progression;
using RPG_Game.Interfaces;

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
        spirit:22), IManaUser
{
    public int Mana { get; set; } = 180;
    public int MaxMana { get; set; } = 180;
    
    public int NeedMana { get; set; }
    protected override StatGrowth StatGrowth => new (1, 1, 1, 2, 2, 0);
    protected override string ClassName =>  "Маг";
    protected override int Damage { get; set; } 
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
    
    protected override void OnLevelUp()
    {
        base.OnLevelUp();
        IManaUser manaUser = this;
        manaUser.IncreaseMaxMana(Level.Level*StatGrowth.IntellectMultiplier);
        manaUser.RestoreFullMana();
    }
    
    public override void DisplayCharacterStats()
    { 
        Console.Write($"Персонаж: {Name}, {ClassName}, {Level.Level} уровень");
        Console.WriteLine($"Здоровье: {Health}/{MaxHealth}");
        Console.WriteLine($"Мана: {Mana}/{MaxMana}");
        base.DisplayCharacterStats();
    }
    
    public override void ShowAbilities()
    {
        // меню заклинаний мага
    }
    
    public override void Attack(Monster target, int resource)
    {
        if (Mana >= resource)
        {
            Mana -= resource;
            base.Attack(target);
        }
        
    }
    
    /// <summary>
    /// Выпускает ледяной снаряд в противника.
    /// </summary>
    private void IceArrow(Monster target)
    {
        NeedMana = 10;
        Damage = Intellect;
        Attack(target, NeedMana);
    }
    
    /// <summary>
    /// Создаёт огненный шар и направляет его в противника.
    /// </summary>
    private void Fireball(Monster target)
    {
        NeedMana = 15;
        Damage = (int)Math.Round(Intellect*1.5);
        Attack(target, NeedMana);
    }
    
    /// <summary>
    /// Обрушивает на противника мощный электрический разряд.
    /// </summary>
    private void LightningBlast(Monster target)
    {
        NeedMana = 20;
        Damage = Intellect*2;
        Attack(target, NeedMana);
    }
}