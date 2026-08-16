using RPG_Game.Characters.Heroes;

namespace RPG_Game.Characters.Monsters;

/// <summary>
/// Представляет лесного тролля — свирепого обитателя лесов.
/// При низком уровне здоровья впадает в ярость и наносит увеличенный урон.
/// </summary>
public class ForestTroll()
    : Monster(name:"Лесной тролль", 
        health:140, 
        armor:20, 
        damage:28, 
        expReward: 50,
        goldReward: 25)
{
    private readonly double _berserkHealthPercent = 0.3;
    
    private readonly double _berserkDamageMultiplier = 1.5;
    protected override BattleMessages Messages => new()
    {
        DamageMessages =
        {
            "🌲🧌 Лесной тролль с рыком обрушивает кулак на героя!",
            "🌲🧌 Тролль заносит огромную лапу и наносит сокрушительный удар!",
            "💥 Тролль сотрясает землю мощным ударом!",
            "🌲🧌 Тролль ревёт и со всей силы бьёт героя!",
            "🪨 Огромный кулак тролля обрушивается на противника!"
        },
        MissMessages =
        {
            "🌲🧌 Тролль замахивается, но герой успевает отскочить!",
            "💨 Огромный кулак тролля проходит мимо героя!",
            "🌲🧌 Тролль яростно бьёт, но промахивается!",
            "🪨 Тролль обрушивает кулак на землю вместо героя!",
            "🌲🧌 Герой успевает увернуться от сокрушительного удара тролля!"
        },
        SpecialMessages =
        {
            "🌲🧌 Лесной тролль впадает в ярость! Его удары становятся сильнее!",
            "🩸 Ярость охватывает тролля! Он с новой силой бросается в атаку!",
            "🌲🧌 Глаза тролля наливаются кровью, а его ярость растёт!",
            "💢 Тролль приходит в бешенство и обрушивает на врага всю свою силу!",
            "🧌 Рёв тролля сотрясает лес! Его ярость делает его ещё опаснее!"
        }
    };
    
    public override void Attack(Hero target, int? damage = null)
    {
        int realDamage = damage ?? Damage;
        if (Health < MaxHealth * _berserkHealthPercent)
        {
            realDamage = (int)Math.Round(Damage*_berserkDamageMultiplier);
            Messages.ShowSpecialMessage();
        }
        base.Attack(target, realDamage);
    }
}