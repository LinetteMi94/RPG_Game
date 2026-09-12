using RPG_Game.Characters.Monsters;
using RPG_Game.Enums;
using RPG_Game.Magic;
using RPG_Game.Messages;
using RPG_Game.Progression;

namespace RPG_Game.Characters.Heroes;

/// <summary>
/// Представляет воина — мастера ближнего боя с высокой силой, бронёй и выносливостью.
/// Наносит мощные физические атаки и способен выдерживать большой урон.
/// </summary>
public class Warrior(string name)
    : Hero(name, 
        health:57, 
        armor:28, 
        strength:23, 
        agility:20, 
        stamina:25, 
        intellect:16, 
        spirit:16)
{
    protected override StatGrowth StatGrowth => new(2, 1, 2, 1, 1, 3,0);
    protected override string ClassName =>  "Воин";
    public override Resources ResourceName => Resources.Ярость;
    public override int Resource { get; set; } = 0;
    public override int MaxResource { get; set; } = 100;
    public override List<Spell> LearnedSpells { get; set; }
    public override List<Spell> SpellsToLearn { get; set; }
    protected override BattleMessages Messages => new()
    {
        DamageMessages =
        {
            "⚔️ Воин с силой обрушивает оружие на противника!",
            "🛡️ Воин наносит мощный удар!",
            "⚔️ Воин замахивается и пробивает защиту противника!",
            "💥 Сокрушительный удар воина обрушивается на врага!",
            "⚔️ Воин наносит тяжёлый удар своим оружием!",
            "🪓 Воин со всей силы обрушивает оружие на противника!",
            "⚔️ Воин проводит стремительную атаку!",
            "💥 Мощный удар воина заставляет противника пошатнуться!",
            "⚔️ Воин находит брешь в защите врага!",
            "🔥 Воин вкладывает всю силу в сокрушительный удар!"
        },
        MissMessages =
        {
            "⚔️ Воин замахивается, но противник успевает увернуться!",
            "🛡️ Удар воина проходит мимо!",
            "⚔️ Воин промахивается, и его оружие рассекает воздух!",
            "💨 Противник ловко отскакивает от удара воина!",
            "⚔️ Воин наносит удар, но не попадает!",
            "🪓 Воин обрушивает оружие на врага, но тот уклоняется!",
            "⚔️ Удар воина проходит слишком далеко от цели!",
            "💨 Противник успевает сделать шаг в сторону!",
            "⚔️ Воин теряет равновесие после промаха!",
            "🛡️ Сильный замах воина заканчивается ударом в пустоту!"
        }
    };
}