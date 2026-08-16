using RPG_Game.Characters.Heroes;

namespace RPG_Game.Characters.Monsters;

/// <summary>
/// Представляет зомби — ожившего мертвеца.
/// Может восстанавливать здоровье во время боя.
/// </summary>
public class Zombie()
    : Monster(name:"Зомби", 
        health:120, 
        armor:15, 
        damage:25, 
        expReward: 35,
        goldReward: 10)
{
    private readonly int _regenerationAmount = 10;

    protected override BattleMessages Messages => new()
    {
        DamageMessages =
        {
            "🧟 Зомби медленно тянется к герою и наносит удар!",
            "🧟 Зомби с хрипом обрушивает гнилые руки на героя!",
            "☠️ Зомби вцепляется в героя мёртвой хваткой!",
            "🧟 Зомби рычит и наносит тяжёлый удар!",
            "☠️ Гнилая рука зомби обрушивается на противника!"
        },
        MissMessages =
        {
            "🧟 Зомби замахивается, но герой успевает отойти!",
            "💨 Медленный удар зомби проходит мимо героя!",
            "🧟 Зомби тянется к герою, но не может его достать!",
            "☠️ Зомби хватает воздух вместо героя!",
            "🧟 Зомби с рыком наносит удар, но промахивается!"
        },
        SpecialMessages =
        {
            "🧟 Зомби восстанавливает часть потерянного здоровья!",
            "☠️ Тело зомби начинает срастаться, и его раны затягиваются!",
            "🧟 Гнилые ткани зомби восстанавливаются прямо на глазах!",
            "☠️ Зомби регенерирует и возвращает часть здоровья!",
            "🧟 Зомби поднимается после удара, восстанавливая свои силы!"
        }
    };

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (damage > Armor && new Random().Next(100) < 30)
        {
            Messages.ShowSpecialMessage();
            Console.WriteLine($"Восстанавлено {_regenerationAmount} здоровья!");
            Health += _regenerationAmount;
        }
    }
}