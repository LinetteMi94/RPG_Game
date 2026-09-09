using System;
using RPG_Game.Characters.Heroes;
using RPG_Game.Characters.Monsters;
using RPG_Game.Input;
using RPG_Game.Interfaces;
using RPG_Game.Items;

namespace RPG_Game.Game;

public static class AttackMenu
{
    public static bool ShowMageBattleMenu(Monster? monster, Action<int, Monster> handleChoice)
    {
        Console.Clear();
        Console.WriteLine($"Каким заклинанием ты хочешь атаковать {monster.Name}?");
        Console.WriteLine("1. Ледяная стрела");
        Console.WriteLine("2. Огненный шар");
        Console.WriteLine("3. Взрывная волна");
        Console.WriteLine("4. Назад");
        int choice = InputValidator.GetValidInput(null,4);
        if(choice == 4) return false;
        handleChoice(choice, monster);
        return true;
    }
}