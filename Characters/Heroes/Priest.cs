using RPG_Game.Interfaces;
using RPG_Game.Messages;
using RPG_Game.Progression;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет жреца — целителя, владеющего силами света.
/// Может восстанавливать здоровье союзников и использовать магические атаки.
/// </summary>
public class Priest(string name) 
    : Hero(name, 
        health:54, 
        armor:20, 
        strength:12, 
        agility:18, 
        stamina:20, 
        intellect:24, 
        spirit:22), 
        IHealer<Hero>, IManaUser
{
    public int Mana { get; set; } = 180;
    public int MaxMana { get; set; } = 180;
    public int NeedMana { get; set; }
    protected override StatGrowth StatGrowth => new(1, 1, 1, 2, 2, 0);
    protected override string ClassName => "Жрец";
    protected override BattleMessages Messages => new()
    {
        DamageMessages =
        {
            "✨ Прист обрушивает на врага силу Света!",
            "🌟 Священная энергия поражает противника!",
            "✨ Луч Света пронзает врага!",
            "🙏 Прист призывает силу веры и наносит священный удар!",
            "🌑 Тёмная энергия вырывается из рук приста и поражает врага!",
            "🖤 Прист обрушивает на противника силу Тьмы!",
            "☠️ Тёмная магия истощает жизненные силы врага!",
            "🌑 Тёмная вспышка поражает противника!",
            "✨ Сила Света пронзает защиту врага!",
            "🖤 Теневые силы подчиняются воле приста и атакуют противника!"
        },
        MissMessages =
        {
            "✨ Луч Света проходит мимо цели!",
            "🌟 Священная энергия рассеивается, не задев противника!",
            "✨ Прист направляет силу Света, но промахивается!",
            "🙏 Священный удар не достигает цели!",
            "🌑 Поток тёмной энергии проходит мимо противника!",
            "🖤 Тёмная магия рассеивается, не задев врага!",
            "☠️ Проклятие не достигает цели!",
            "🌑 Теневой заряд проходит рядом с противником!",
            "✨ Вспышка Света поражает землю рядом с врагом!",
            "🖤 Тьма окружает противника, но не причиняет ему вреда!"
        },
        HealMessages =
        {
            "✨ Прист призывает силу Света и исцеляет раны!",
            "🌟 Священная энергия восстанавливает жизненные силы!",
            "🙏 Благословение Света возвращает здоровье!",
            "✨ Свет окутывает тело и ускоряет восстановление!",
            "🌑 Прист поглощает тёмную энергию и восстанавливает силы!",
            "🖤 Тёмная магия возвращает часть утраченного здоровья!",
            "🌑 Прист направляет силу Тьмы, обращая её в жизненную энергию!",
            "☠️ Тёмная энергия переплетается с душой и укрепляет тело!",
            "✨🌑 Свет и Тьма подчиняются воле приста, возвращая ему силы!",
            "🖤 Прист использует запретное заклинание для восстановления здоровья!"
        }
    };

    protected override int Damage  { get; set; } 
    
    public int HealPower => (Intellect + Spirit)/2;

    public void Heal()
    {
        Messages.ShowHealMessage();
        RestoreHealth(HealPower);
    }
    
    public void Heal(Hero hero) => hero.RestoreHealth(HealPower);
    
    public override void DisplayCharacterStats()
    { 
        Console.Write($"Персонаж: {Name}, {ClassName}, {Level.Level} уровень");
        Console.WriteLine($"Здоровье: {Health}/{MaxHealth}");
        Console.WriteLine($"Мана: {Mana}/{MaxMana}");
        base.DisplayCharacterStats();
    }
    
    public override void ShowAbilities()
    {
        // меню заклинаний жреца
    }
}