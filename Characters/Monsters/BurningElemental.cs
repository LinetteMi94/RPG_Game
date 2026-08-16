using RPG_Game.Characters.Heroes;
using RPG_Game.Items;

namespace RPG_Game.Characters.Monsters;

/// <summary>
/// Представляет горящего элементаля — существо из огненной энергии.
/// Имеет шанс нанести дополнительный урон огнём во время атаки.
/// </summary>
public class BurningElemental() 
    : Monster(name:"Горящий элементаль", 
        health:100, 
        armor:10, 
        damage:30, 
        expReward: 40,
        goldReward: 15)
{
    private readonly int _fireChance = 30;
    private readonly int _fireDamage = 20;
    
    protected override BattleMessages Messages => new()
    {
        DamageMessages =
        {
            "🔥 Элементаль обрушивает огненный удар на героя!",
            "🔥 Пламя вспыхивает вокруг элементаля и поражает героя!",
            "🌋 Элементаль выпускает поток раскалённой энергии!",
            "🔥 Огненный кулак элементаля обрушивается на противника!",
            "🔥 Элементаль вспыхивает и атакует героя бушующим пламенем!"
        },
        MissMessages =
        {
            "🔥 Огненный удар элементаля проходит мимо героя!",
            "💨 Пламя проносится рядом с героем!",
            "🔥 Элементаль выпускает поток огня, но промахивается!",
            "🌋 Огненная атака ударяет рядом с героем!",
            "🔥 Герой успевает увернуться от пылающего удара!"
        },
        SpecialMessages =
        {
            "🔥 Элементаль усиливает удар бушующим пламенем!",
            "🔥 Огненная энергия вспыхивает на теле героя!",
            "🔥 Элементаль окутывает героя пламенем!",
            "🔥 Жар от атаки элементаля обжигает героя!",
            "🔥 Пламя в руках элементаля вспыхивает с новой силой и обжигает героя!"
        }
    };
    public override List<Item> Loot { get; } =
    [
        new ("Осколок огненного ядра",
            "Кусочек кристаллизованного пламени из сердца элементаля.",
            25),
        
        new ("Тлеющий уголь",
            "Обычный уголь, который всё ещё хранит тепло элементаля.",
            5),

        new ("Пепельный камень",
            "Серый камень, пропитанный остатками огненной магии.",
            10),
        
        new ("Огненный кристалл",
            "Редкий кристалл, наполненный энергией пламени.",
            100),
        
        new ("Пылающее ядро элементаля",
            "Источник силы огненного создания. Очень ценная находка.",
            250),

        new ("Обугленный кусок брони",
            "Остаток доспеха несчастного воина, поглощённого пламенем."),

        new ("Горячий камешек",
            "Нагретый камень. Красиво светится, но бесполезен."),

        new ("Искра элементаля",
            "Маленький огненный дух, застывший внутри кристалла.",
            75),
        
        new ("Пепел древнего пламени",
            "Говорят, этот пепел сохраняет часть магии побеждённого элементаля.",
            150)
    ];
    
    public override void Attack(Hero target, int? damage = null)
    {
        int realDamage = damage ?? Damage;
        if (IsAlive)
        {
            if (realDamage > target.Armor)
            {
                target.TakeDamage(realDamage);
                Messages.ShowDamageMessage();
                Console.WriteLine($"{Name} наносит {realDamage - target.Armor} урона {target.Name}!");
                Console.WriteLine($"{target.Name}, здоровье {target.Health}/{target.MaxHealth}!");
                bool fireAttack = new Random().Next(100) < _fireChance;
                if (fireAttack)
                {
                    target.TakeDamage(_fireDamage, true);
                    Messages.ShowSpecialMessage();
                    Console.WriteLine($"Нанесено {_fireDamage} дополнительного урона от огня🔥!");
                    Console.WriteLine($"{target.Name}, здоровье {target.Health}/{target.MaxHealth}!");
                }
            }
            else Messages.ShowMissMessage();
            Console.WriteLine();
        }
    }
}