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

        const string Dice0Row1 = "              ________ ";
        const string Dice0Row2 = "             /       /|";
        const string Dice0Row3 = "            /_______/ |";

        const string Dice1Row4 = "            |       | |";
        const string Dice1Row5 = "            |   o   | /";
        const string Dice1Row6 = "            |       |/";

        const string Dice2Row4 = "            | o     | |";
        const string Dice2Row5 = "            |       | /";
        const string Dice2Row6 = "            |     o |/";

        const string Dice3Row4 = "            | o     | |";
        const string Dice3Row5 = "            |   o   | /";
        const string Dice3Row6 = "            |     o |/ ";

        const string Dice4Row4 = "            | o   o | |";
        const string Dice4Row5 = "            |       | /";
        const string Dice4Row6 = "            | o   o |/ ";

        const string Dice5Row4 = "            | o   o | |";
        const string Dice5Row5 = "            |   o   | /";
        const string Dice5Row6 = "            | o   o |/ ";

        const string Dice6Row4 = "            | o   o | |";
        const string Dice6Row5 = "            | o   o | /";
        const string Dice6Row6 = "            | o   o |/ ";


        const string Dice0Row7 = "            '-------'  ";

        int op;
        int wizardLevel = 0;
        int hoursTrained = 0;
        string wizardName = "";
        string title = "";
        Random rnd = new Random();

        do {
            Console.WriteLine(MenuTitle);
            if (!string.IsNullOrEmpty(wizardName))
            {
                Console.WriteLine(MenuWelcome, wizardName, title, wizardLevel);
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
                        wizardLevel += rnd.Next(1, 11);
                        Console.WriteLine(TrainingOutput, i, wizardName, hoursTrained, wizardLevel);
                    }

                    switch (wizardLevel)
                    {
                        case >= 40:
                            Console.WriteLine(TitleAdvanced);
                            title = "ITB - Wizard the Gray";
                            break;
                        case >= 35:
                            Console.WriteLine(TitleHigh);
                            title = "Elarion of the Embers";
                            break;
                        case >= 30:
                            Console.WriteLine(TitleMedium);
                            title = "Arka Nullpointer";
                            break;
                        case >= 20:
                            Console.WriteLine(TitleBasic);
                            title = "Zyn the Bugged";
                            break;
                        case < 20:
                            Console.WriteLine(TitleFail);
                            title = "Raoden the Elantry";
                            break;
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