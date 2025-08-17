using System;

namespace TurnBasedCombatGame
{
    public class Inventory
    {
        private Dictionary<string, int> items;

        public Inventory()
        {
            items = new Dictionary<string, int>();
        }

        public void AddItem(string itemName, int amount)
        {
            if (items.ContainsKey(itemName))
            {
                items[itemName] += amount;
            }
            else
            {
                items.Add(itemName, amount);
            }

            if (items[itemName] <= 0)
            {
                items.Remove(itemName);
            }
        }

        public bool RemoveItem(string itemName, int amount)
        {
            if (items.ContainsKey(itemName))
            {
                items[itemName] -= amount;

                if (items[itemName] <= 0)
                {
                    items.Remove(itemName);
                }
                return true;
            }
            return false;
        }

        public bool HasItem(string itemName)
        {
            return items.ContainsKey(itemName) && items[itemName] > 0;
        }

        public void DisplayInventory()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
                return;
            }

            Console.WriteLine("Your inventory contains:");
            foreach (var item in items)
            {
                Console.WriteLine($"- {item.Key}: {item.Value}");
            }
        }
    }
}

