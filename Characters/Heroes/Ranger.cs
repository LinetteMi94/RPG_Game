using System;
using RPG_Game.Characters.Monsters;
using RPG_Game.Messages;
using RPG_Game.Progression;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет следопыта — дальнего бойца, использующего ловкость и точность.
/// Наносит урон с расстояния и полагается на меткие атаки.
/// </summary>
public class Ranger(string name)
    : Hero(name,
        health: 55,
        armor: 20,
        strength: 15,
        agility: 24,
        stamina: 21,
        intellect: 18,
        spirit: 19)
{
    protected override string ClassName =>  "Следопыт";
    protected override StatGrowth StatGrowth => new(1, 2, 2, 1, 1, 1);
    protected override BattleMessages Messages => new()
    {
        DamageMessages =
        {
            "🏹 Следопыт выпускает стрелу точно в цель!",
            "🎯 Следопыт делает меткий выстрел!",
            "🏹 Стрела со свистом вонзается в противника!",
            "🎯 Следопыт находит слабое место и поражает врага!",
            "🏹 Стремительная стрела поражает противника!",
            "🔥 Следопыт активирует огненную ловушку под ногами врага!",
            "❄️ Ледяная ловушка срабатывает, сковывая противника!",
            "🌑 Следопыт скрывается в тени и выпускает неожиданную стрелу!",
            "🔥 Огненная ловушка вспыхивает, опаляя противника!",
            "❄️ Ледяная ловушка сковывает ноги противника!"
        },
        MissMessages =
        {
            "🏹 Следопыт выпускает стрелу, но противник успевает увернуться!",
            "🎯 Стрела проходит мимо цели!",
            "🏹 Выстрел Следопыт уходит в сторону!",
            "🌲 Стрела вонзается в землю рядом с противником!",
            "💨 Противник резко отступает, и стрела пролетает мимо!",
            "🔥 Огненная ловушка срабатывает, но противник успевает отскочить!",
            "❄️ Ледяная ловушка захлопывается, но противник успевает вырваться!",
            "🌑 Следопыт стреляет из тени, но противник замечает движение!",
            "🎯 Стрела едва не задевает противника!",
            "💨 Следопыт теряет момент, и выстрел проходит мимо!"
        }
    };

    protected override int Damage { get; set; } 
    
    public override void DisplayCharacterStats()
    { 
        Console.Write($"Персонаж: {Name}, {ClassName}, {Level.Level} уровень");
        Console.WriteLine($"Здоровье: {Health}/{MaxHealth}");
        base.DisplayCharacterStats();
    }
    
    public override void ShowAbilities(int choose, Monster target)
    {
        // меню заклинаний следопыта
    }
}