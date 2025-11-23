using System;
using System.Runtime.ExceptionServices;
using System.Threading.Channels;
using System.Xml.Linq;
using System.Xml.Schema;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
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

        const int MeditationDays = 5;
        const string AskName = "Input your wizard's name: ";
        const string WrongName = "You must name your wizard using only letters.";
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

        const string MineLeftAttempts = "You have {0} attempts to mine for bits.";
        const string MineRowNum = "   0  1  2  3  4 ";
        const string AskX = "Insert the X axis:";
        const string AskY = "Insert the Y axis:";
        const string WrongInput = "Invalid input.";
        const string MineNothing = "You mine at position [{0}][{1}] but found nothing.";
        const string MineFound = "You mine at position [{0}][{1}] and you get {2} bits";

        const string EmptyInventory = "Your inventory is empty.";
        const string ShowInventory = "Your inventory contains:";

        const string ShopHeader = "You chose to buy items\nYou have {0} bits available\nItems available for purchase";
        const string ShopChoose = "Select the item you wish to buy (1 - {0}) (0 to exit):";
        const string Purchase = "You have purchased: {0} for {1} bits. Bits remaining: {2}";
        const string CantPurchase = "You do not have enough bits to purchase this item";

        const string AvalAttacks = "Available attacks for level {0}:";
        const string KeepTraining = "Keep training to unlock new powers!";

        bool aux = true;
        int op, actHP, monster, diceResult, actBits, shopOp;
        int axisX = 0;
        int axisY = 0;
        int wizardXP = 0;
        int wizardLevel = 1;
        int hoursTrained = 0;
        int mineAttempts = 5;
        int totalBits = 0;
        string actMonster;
        string wizardName = "";
        string title = "";

        int[] monsterHP = { 3, 5, 10, 11, 18, 15, 20, 50 };
        int[] shopPrices = { 30, 10, 50, 40, 20};
        string[] titlesList = { "Raoden the Elantry", "Zyn the Bugged", "Arka Nullpointer", "Elarion of the Embers", "ITB - Wizard the Gray" };
        string[] monsterNames = { "Wandering Skeleton 💀", "Forest Goblin 👹", "Green Slime 🟢", "Ember Wolf 🐺", "Giant Spider 🕷️", "Iron Golem 🤖", "Lost Necromancer 🧝‍♂️", "Ancient Dragon 🐉" };
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
        string[,] mineBase = {
        { "➖", "➖", "➖", "➖", "➖" },
        { "➖", "➖", "➖", "➖", "➖" },
        { "➖", "➖", "➖", "➖", "➖" },
        { "➖", "➖", "➖", "➖", "➖" },
        { "➖", "➖", "➖", "➖", "➖" }};
        string[,] mineAct;
        string[] inventory = new string[0];
        string[] inventoryAux;
        string[] shopItems = { "Iron Dagger 🗡️", "Healing Potion ⚗️", "Ancient Key 🗝️", "Crossbow 🏹", "Metal Shield 🛡️" };
        string[][] attacks = new string[][]
        {
            new string[] {"Magic Spark 💫"},
            new string[] {"Fireball 🔥", "Ice Ray 🥏", "Arcane Shield ⚕️"},
            new string[] {"Meteor ☄️", "Pure Energy Explosion 💥", "Minor Charm 🎭", "Air Strike 🍃"},
            new string[] {"Wave of Light ⚜️", "Storm of Wings 🐦"},
            new string[] { "Cataclysm 🌋", "Portal of Chaos 🌀", "Arcane Blood Pact 🩸", "Elemental Storm ⛈️" }
        };
            
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
                op = -1;
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
                            } else
                            {
                                try
                                {
                                    wizardName = wizardName.Trim();
                                    wizardName = wizardName.ToLower();
                                    wizardName = char.ToUpper(wizardName[0]) + wizardName.Substring(1);
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine(WrongName);
                                    wizardName = "";
                                }
                            }
                        } while (string.IsNullOrEmpty(wizardName));
                    }

                    for (int i = 1; i <= MeditationDays; i++)
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

                case 3:
                    Console.WriteLine(MineLeftAttempts, mineAttempts);
                    mineAct = mineBase;
                    for (int i = 0; i < mineAttempts; i++) {
                        Console.WriteLine(MineRowNum);
                        for (int j = 0; j < mineAct.GetLength(0); j++)
                        {
                            Console.Write($"{j} ");
                            for (int l = 0; l <  mineAct.GetLength(1); l++)
                            {
                                Console.Write($"{mineAct[j,l]} ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        do
                        {
                            Console.WriteLine(AskX);
                            try
                            {
                                axisX = int.Parse(Console.ReadLine());
                                aux = true;
                                if (axisX < 0 || axisX > 4)
                                {
                                    Console.WriteLine(WrongInput);
                                    aux = false;
                                }
                            } catch (Exception)
                            {
                                Console.WriteLine(WrongInput);
                                aux = false;
                            }
                        } while (!aux);
                        do
                        {
                            Console.WriteLine(AskY);
                            try
                            {
                                axisY = int.Parse(Console.ReadLine());
                                aux = true;
                                if (axisY < 0 || axisY > 4)
                                {
                                    Console.WriteLine(WrongInput);
                                    aux = false;
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine(WrongInput);
                                aux = false;
                            }
                        } while (!aux);

                        actBits = rnd.Next(0, 75);
                        if (actBits < 5 || actBits > 50)
                        {
                            Console.WriteLine(MineNothing, axisX, axisY);
                            mineAct[axisX, axisY] = "❌";
                        } else
                        {
                            Console.WriteLine(MineFound, axisX, axisY, actBits);
                            totalBits += actBits;
                            mineAct[axisX, axisY] = "🪙";
                        }

                    }
                    for (int j = 0; j < mineAct.GetLength(0); j++)
                    {
                        Console.Write($"{j} ");
                        for (int l = 0; l < mineAct.GetLength(1); l++)
                        {
                            Console.Write($"{mineAct[j, l]} ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    break;
                case 4:
                    if (inventory.Length == 0)
                    {
                        Console.WriteLine(EmptyInventory);
                    } else
                    {
                        Console.WriteLine(ShowInventory);
                        foreach (string item in inventory) {
                            Console.WriteLine("\t" + item);
                        } 
                    }
                        break;

                case 5:
                    Console.WriteLine(ShopHeader, totalBits);
                    for (int i = 0; i < shopItems.Length; i++) {
                        Console.WriteLine($"{i + 1} - {shopItems[i]} - Price {shopPrices[i]}");
                    }
                    do
                    {
                        Console.WriteLine(ShopChoose);

                        try
                        {
                            shopOp = int.Parse(Console.ReadLine());
                            if (shopOp < shopItems.Length + 1 && shopOp >= 0)
                            {
                                aux = true;
                            }
                            else
                            {
                                Console.WriteLine(WrongInput);
                                aux = false;
                            }

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine(WrongInput);
                            shopOp = -1;
                            aux = false;
                        }
                    } while (!aux);

                    switch (shopOp)
                    {
                        case 0:
                            break;
                        default:
                            shopOp--;
                            if (totalBits >= shopPrices[shopOp]) {
                                totalBits -= shopPrices[shopOp];
                                Console.WriteLine(Purchase, shopItems[shopOp], shopPrices[shopOp], totalBits);
                                inventoryAux = new string[inventory.Length + 1];
                                for (int i = 0; i < inventory.Length; i ++)
                                {
                                    inventoryAux[i] = inventory[i];
                                }
                                inventoryAux[inventory.Length] = shopItems[shopOp];
                                inventory = inventoryAux;
                            } else
                            {
                                Console.WriteLine(CantPurchase);
                            }
                                break;
                    }
                    break;
                case 6:
                    Console.WriteLine(AvalAttacks, wizardLevel);
                    foreach (string attack in attacks[wizardLevel - 1]) {
                        Console.WriteLine(attack);
                    }
                    Console.WriteLine(wizardLevel < 5? KeepTraining : MaxLevel, wizardName);
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