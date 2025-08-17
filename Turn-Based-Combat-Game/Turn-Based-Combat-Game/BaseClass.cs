using System;

namespace TurnBasedCombatGame
{
	public abstract class BaseClass : ICharacter
	{
		public string Name { get; set; }
		public int Health { get; set; }
		public bool isDefending { get; set; }

        public Inventory inventory { get; private set; }

		public BaseClass(string name)
		{
			Name = name;
			Health = 20;
			isDefending = false;
            inventory = new Inventory();
		}

		public abstract void Attack(Enemy enemy);

		public virtual void TakeDamage(int damage)
		{
			Health -= damage;
			Console.WriteLine($"The player has taken {damage} damage, and is now at {Health}hp");

			if (Health <= 0)
			{
				Health = 0;
				Console.WriteLine("You have been killed!");
                // Either end game or Load a recent save - not yet implemented recent save feature.
                // PLEASE COME BACK TO THIS AFTER COMBAT IS TESTED
            }
        }

        public virtual bool UseHealPotion()
        {
            if (inventory.HasItem("Healing Potion"))
            {
                int healPoints = 5;
                Health += healPoints;
                inventory.RemoveItem("Healing Potion", 1);
                Console.WriteLine($"\nYou used a heal potion and restored {healPoints}hp. Total health: {Health}hp.");
                return true;
            }
            else
            {
                Console.WriteLine("You are out of healing potions!");
                return false;
            }
        }

        public string GetName()
        {
            return Name;
        }

        public int GetHealth()
        {
            return Health;
        }
    }
}
