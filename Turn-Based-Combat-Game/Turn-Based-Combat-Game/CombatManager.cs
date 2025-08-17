using System;

namespace TurnBasedCombatGame
{
    public class CombatManager
    {
        public CombatManager()
        {

        }

        public void StartCombat(ICharacter player, Enemy enemy)
        {
            bool inCombat = true;
            int roundCount = 1;

            Console.WriteLine("Combat has begun!");

            while (inCombat)
            {
                while (player.GetHealth() > 0 && enemy.GetHealth() > 0)
                {
                    Console.WriteLine("\nPlayer Turn!");
                    Delay(2000);

                    Console.WriteLine("\nChoose Action: \n1. Attack \n2. Defend \n3. View Inventory");
                    int action = Convert.ToInt32(Console.ReadLine());

                    switch (action)
                    {
                        case 1:
                            player.Attack(enemy);
                            Delay(2000);
                            break;
                        case 2:
                            player.isDefending = true;
                            Console.WriteLine("\nYou prepare to block the next attack..");
                            Delay(2000);
                            break;
                        case 3:
                            Console.WriteLine("\nInventory:");
                            player.inventory.DisplayInventory();

                            Console.WriteLine("\nPlease choose and item to use: (or 0 to go back):");
                            string choice = Console.ReadLine();

                            if (choice.ToLower() == "healing potion")
                            {
                                bool usedHealPotion = player.UseHealPotion();

                                if (!usedHealPotion)
                                {
                                    continue;
                                }
                            }
                            else if (choice == "0")
                            {
                                Console.WriteLine("Closing Inventory.. ");
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice, please choose again.");
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
                    enemy.Attack(player);
                    Delay(2000);

                    if (player.GetHealth() <= 0)
                    {
                        Console.WriteLine("Player is defeated! You Lose..");
                        break;
                    }

                    Console.WriteLine($"\nRound {roundCount} over, loading current stats..");
                    Delay(3000);
                    Console.WriteLine("\nStatus:");
                    Console.WriteLine($"Player's Current Health: {player.GetHealth()}hp");
                    Console.WriteLine($"Enemy's Current Health: {enemy.GetHealth()}hp");
                    Console.WriteLine("Press Enter to continue.. ");
                    Console.ReadLine();

                    roundCount++;
                }
                inCombat = false;
            }
        }

        public void Delay(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }
    }
}
