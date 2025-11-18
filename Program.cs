using System;
using System.Threading.Channels;
using System.Xml.Linq;

public class Program
{
    public static void Main()
    {
        const string MenuTitle = "===== MAIN MENU - CODEQUEST =====";
        const string MenuWelcome = "===== Welcome, {0} the {1} with level {2} =====";
        const string MenuOption1 = "1. Train your wizard";
        const string MenuOption2 = "2. Increase LVL (Update)";
        const string MenuOption3 = "3. Loot the mine (New!)";
        const string MenuOption4 = "4. Show inventory (New!)";
        const string MenuOption5 = "5. Buy items (New!)";
        const string MenuOption6 = "6. Show attacks by LVL (New!)";
        const string MenuOption7 = "7. Decode ancient Scroll (New!)";
        const string MenuOptionExit = "0. Exit game";
        const string MenuPrompt = "Choose an option (1-7) - (0) to exit: ";
        const string InputErrorMessage = "Invalid input. Please enter a number between 0 and 7.";

        const int meditationDays = 5;
        const string AskName = "Input your wizard's name: ";
        const string WrongName = "You must name your wizard.";
        const string TrainingOutput = "Day {0}: {1} has trained for a total of {2} hours and gained {3} power points.";
        const string TitleFail = "You fail. To second call.";
        const string TitleBasic = "You still mistake a wand with a spoon.";
        const string TitleMedium = "You're a Magic Wind Summoner.";
        const string TitleHigh = "Wow! You can summon dragons without burning the lab!";
        const string TitleAdvanced = "You assumed Arcanes Master's rank!";
        const string EndTraining = "Training complete! {0} has achieved a total power of {1} and earned the title '{2}'";

        const string MonsterAppears = "A wild {0} appears! Rolling dice to determine the outcome of the battle...";
        const string MonsterHPMessage = "The {0} has {1} HP";
        const string DiceRollMessage = "You rolled a {0}!";
        const string MonsterTakeDamage = "The monster takes damage!";
        const string RollAgain = "Press any key to roll the dice again...";
        const string MonsterDefeated = "The {0} has been defeated!";
        const string LevelUp = "{0} levels up!";
        const string MaxLevel = "{0} already reached the max level";

        int op, actHP, monster, diceResult;
        int wizardXP = 0;
        int wizardLevel = 1;
        int hoursTrained = 0;
        string actMonster;
        string wizardName = "";
        string title = "";

        int[] monsterHP = { 3, 5, 10, 11, 18, 15, 20, 50 };
        string[] titlesList = { "Raoden the Elantry", "Zyn the Bugged", "Arka Nullpointer", "Elarion of the Embers", "ITB - Wizard the Gray" };
        string[] monsterNames = { "Wandering Skeleton", "Forest Goblin", "Green Slime", "Ember Wolf", "Giant Spider", "Iron Golem", "Lost Necromancer", "Ancient Dragon"};
        string[] dice =
        {
            "   ________\r\n  /       /|   \r\n /_______/ |\r\n |       | |\r\n |   o   | /\r\n |       |/ \r\n '-------'\r\n",
            "   ________\r\n  /       /|   \r\n /_______/ |\r\n | o     | |\r\n |       | /\r\n |     o |/ \r\n '-------'\r\n",
            "   ________\r\n  /       /|   \r\n /_______/ |\r\n | o     | |\r\n |   o   | /\r\n |     o |/ \r\n '-------'\r\n",
            "   ________\r\n  /       /|   \r\n /_______/ |\r\n | o   o | |\r\n |       | /\r\n | o   o |/ \r\n '-------'\r\n",
            "   ________\r\n  /       /|   \r\n /_______/ |\r\n | o   o | |\r\n |   o   | /\r\n | o   o |/ \r\n '-------'\r\n",
            "   ________\r\n  /       /|   \r\n /_______/ |\r\n | o   o | |\r\n | o   o | /\r\n | o   o |/ \r\n '-------'\r\n"
        };
        //I do the dice as an array so I can't avoid doing a long condition afterwards, and I can show whatever I need with just one line that works for all the dice sides

        Random rnd = new Random();

        do {
            Console.WriteLine(MenuTitle);
            if (!string.IsNullOrEmpty(wizardName))
            {
                Console.WriteLine(MenuWelcome, wizardName, title, wizardXP);
            }
            Console.WriteLine(MenuOption1);
            Console.WriteLine(MenuOption2);
            Console.WriteLine(MenuOption3);
            Console.WriteLine(MenuOption4);
            Console.WriteLine(MenuOption5);
            Console.WriteLine(MenuOption6);
            Console.WriteLine(MenuOption7);
            Console.WriteLine(MenuOptionExit);
            Console.WriteLine(MenuPrompt);

            try
            {
                op = int.Parse(Console.ReadLine());
            }
            catch (Exception) {
                op = 8;
            }

            switch (op)
            {
                case 1:
                    if (string.IsNullOrEmpty(wizardName))
                    {
                        do
                        {
                            Console.WriteLine(AskName);
                            wizardName = Console.ReadLine();

                            if (string.IsNullOrEmpty(wizardName))
                            {
                                Console.WriteLine(WrongName);
                            }
                        } while (string.IsNullOrEmpty(wizardName));
                    }
                    
                    wizardName = wizardName.Trim();
                    wizardName = wizardName.ToLower();
                    wizardName = char.ToUpper(wizardName[0]) + wizardName.Substring(1);

                    for (int i = 1; i <= meditationDays; i++)
                    {
                        hoursTrained += rnd.Next(1, 25);
                        wizardXP += rnd.Next(1, 11);
                        Console.WriteLine(TrainingOutput, i, wizardName, hoursTrained, wizardXP);
                    }

                    switch (wizardXP)
                    {
                        case < 20:
                            title = titlesList[0];
                            Console.WriteLine(TitleFail);
                            break;
                        case < 30:
                            title = titlesList[1];
                            Console.WriteLine(TitleBasic);
                            break;
                        case < 35:
                            title = titlesList[2];
                            Console.WriteLine(TitleMedium);
                            break;
                        case < 40:
                            title = titlesList[3];
                            Console.WriteLine(TitleHigh);
                            break;
                        case >= 40:
                            title = titlesList[4];
                            Console.WriteLine(TitleAdvanced);
                            break;
                    }
                    Console.WriteLine(EndTraining, wizardName, wizardXP, title);
                    break;
                case 2:
                    monster = rnd.Next(0, monsterNames.Length);
                    actHP = monsterHP[monster];
                    actMonster = monsterNames[monster];
                    Console.WriteLine(MonsterAppears, actMonster);
                    Console.WriteLine(MonsterHPMessage, actMonster, actHP);
                    do
                    {
                        diceResult = rnd.Next(1,7);
                        Console.WriteLine(DiceRollMessage, diceResult);
                        Console.WriteLine(dice[diceResult - 1]);
                        actHP = actHP - diceResult  < 0 ? 0 : actHP - diceResult;
                        Console.WriteLine(MonsterTakeDamage);
                        Console.WriteLine(MonsterHPMessage, actMonster, actHP);
                        if (actHP > 0)
                        {
                            Console.WriteLine(RollAgain);
                            Console.ReadLine();
                        }
                    } while (actHP > 0);
                    Console.WriteLine(MonsterDefeated, actMonster);
                    if (wizardLevel < 5)
                    {
                        Console.WriteLine(LevelUp, wizardName);
                        wizardLevel++;
                    } else
                    {
                        Console.WriteLine(MaxLevel, wizardName);
                    }
                        break;
                case 0:
                    break;
                default:
                    Console.WriteLine(InputErrorMessage);
                    break;
            }

        } while (op != 0);
    }
}