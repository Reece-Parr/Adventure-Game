using Microsoft.VisualBasic.FileIO;
using System;
using System.Formats.Asn1;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Turn_Based_Combat_Game;

namespace TurnBasedCombatGame 
{
    class Game
    {
        static void Main(string[] args)
        {
            TestCombat();

            // Instances created just to test saving feature.
            Warrior war = new Warrior("Mark");
            FileManager.Save<Warrior>(war, war.Name.ToLower());

            Mage mg = new Mage("Reece");
            FileManager.Save<Mage>(mg, mg.Name.ToLower());

            // Empty Instances created just to test loading feature.
            Warrior warrior = new Warrior();
            Mage mage = new Mage();


            Console.Write("Welcome to 'Adventure Game'. Would you like to \n 1. Create a character \n 2. Load a character \n 3. Exit game \n Answer:");
            int menuOption = Convert.ToInt32(Console.ReadLine());

            switch (menuOption)
            {
                case 1:
                    CreateCharacter();
                    break;
                case 2:
                    Console.Write("Enter the name of your character (Ensure input is identical to file save): ");
                    string fileName = Console.ReadLine().ToLower();

                    Console.Write("Enter the class of your character: ");
                    string cl = Console.ReadLine().ToLower();

                    if (cl.Equals("warrior"))
                    {
                        warrior = FileManager.Load<Warrior>(fileName);
                        Console.WriteLine("Loading your character..");
                        Delay(2000);
                        Console.WriteLine(warrior.ToString());
                        // Need to call Introduction Function when actually using Load feature
                    }
                    else if (cl.Equals("mage"))
                    {
                        mage = FileManager.Load<Mage>(fileName);
                        Console.WriteLine("Loading your character..");
                        Delay(2000);
                        Console.WriteLine(mage.ToString());
                        // Need to call Introduction Function when actually using Load feature
                    } 
                    else
                    {
                        Console.WriteLine("There was an error with loading your file class.");
                    }
                    break;
                case 3:
                    System.Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Invalid Menu Choice!");
                    break;
            }
        }

        public static void TestCombat()
        {
            Mage mage = new Mage("Test");
            Enemy enemy = new Enemy(15);

            bool inCombat = true;
            int roundCount = 1;

            Console.WriteLine("Combat has begun!");

            while (inCombat)
            {
                while (mage.health > 0 && enemy.GetHealth() > 0)
                {
                    Console.WriteLine("\nPlayer Turn!");
                    Delay(2000);

                    Console.WriteLine("\nChoose Action: \n1. Attack \n2. Defend \n3. Heal Potion");
                    int action = Convert.ToInt32(Console.ReadLine());

                    switch(action)
                    {
                        case 1:
                            mage.Attack(enemy);
                            Delay(2000);
                            break;
                        case 2:
                            mage.isDefending = true;
                            Console.WriteLine("\nYou prepare to block the next attack..");
                            Delay(2000);
                            break;
                        case 3:
                            bool usedHealPotion = mage.UseHealPotion();

                            if (!usedHealPotion)
                            {
                                continue;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid Action Choice! Please try again..");
                            break;
                    }

                    if (enemy.GetHealth() <= 0)
                    {
                        Console.WriteLine("All Enemies are defeated! You Win!");
                        break;
                    }

                    Console.WriteLine("\nEnemy Turn...");
                    Delay(2000);
                    enemy.Attack(mage);
                    Delay(2000);

                    if (mage.health <= 0)
                    {
                        Console.WriteLine("Player is defeated! You Lose..");
                        break;
                    }

                    Console.WriteLine($"\nRound {roundCount} over, loading current stats..");
                    Delay(3000);
                    Console.WriteLine("\nStatus:");
                    Console.WriteLine($"Player's Current Health: {mage.health}hp");
                    Console.WriteLine($"Enemy's Current Health: {enemy.GetHealth()}hp");
                    Console.WriteLine("Press Enter to continue.. ");
                    Console.ReadLine();

                    roundCount++;
                }
                inCombat = false;
            }
        }

        public static void Introduction<T>(T choosenClass)
        {

            PrintedWrapped("\nWelcome, adventurer, to the mystical realm of Eldoria, a land steeped in ancient magic and shrouded in secrets.");
            Delay(3000);
            PrintedWrapped("\nAs you step into this fantastical world, you find yourself standing at the crossroads of destiny, where every decision shapes the course of your journey.");
            Delay(3000);
            PrintedWrapped("\nAs you travel down the long road towards Eldoria, you come across a abandoned carriage with a broken wheel and scattered items.");
            Delay(3000);

            Console.ReadLine();
        }

        public static void CreateCharacter() {
            Console.WriteLine("Hello adventurer! Welcome to Eldoria. What may I call you?");
            string? name = Console.ReadLine();
            
            bool isValid = isValidName(name);
            while (!isValid) {
                Console.Write("Your name cannot be blank or include numbers. Enter a new name:");
                name = Console.ReadLine();
                isValid = isValidName(name);
            } 

            bool isConfirm = false;
            while(!isConfirm) 
            {
                Console.WriteLine("Would you like to confirm that name? (y or n)");
                var answer = Console.ReadLine();
                if (answer == "y" || answer == "Y") 
                {
                    isConfirm = true;
                }
                else if (answer == "n" || answer == "N") 
                {
                    Console.WriteLine("Please enter a new name: ");
                    name = Console.ReadLine();
                    continue;
                } 
                else 
                {
                    Console.WriteLine("Invalid input, try again.");
                }
            }

            ICharacter character = ChooseClass(name);

            // ADD DELAY FUNCTION to create a delay between commands for ease of reading.
            Console.WriteLine("Hello " + character.GetName() + ", let's take a look at your current profile & stats...");
            Delay(2000);
            Console.WriteLine(character.ToString());
            Introduction(character);
        }


        public static ICharacter ChooseClass(String? name)
        {
            int option;
            while(true)
            {
                Console.Write("Please choose your class: \n 1. Warrior \n 2. Mage \n Answer:");
                string input = Console.ReadLine();
                
                if (int.TryParse(input, out option))
                {
                    switch(option)
                    {
                        case 1:
                            return new Warrior(name);
                        case 2:
                            return new Mage(name);
                        default:
                            Console.WriteLine("Invalid class input");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
        public static bool isValidName(string? nameInput) 
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(nameInput)) {
                isValid = false;
            } else {
                isValid = Regex.IsMatch(nameInput, @"^[a-zA-Z]+$");
            }

            foreach (char c in nameInput) {
                if(!char.IsLetter(c)) {
                    isValid = false;
                }
            }
            return isValid;
        }

        public static void Delay(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }
        
        public static void PrintedWrapped(string text)
        {
            int width = Console.WindowWidth - 1;
            string[] words = text.Split(" ");
            string line = "";

            foreach (string word in words) 
            {
                if ((line + word).Length > width)
                {
                    Console.WriteLine(line);
                    line = "";
                }
                line += word + " ";
            }
            if (line.Length > 0)
            {
                Console.WriteLine(line);
            }
        }
    }
}