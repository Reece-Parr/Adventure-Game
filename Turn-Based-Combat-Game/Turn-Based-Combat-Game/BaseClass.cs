using System;

namespace TurnBasedCombatGame
{
	public abstract class BaseClass : ICharacter
	{
		public string Name { get; set; }
		public int Health { get; set; }
		public bool isDefending { get; set; }
		public int maxHealth { get; set; }

		protected int healPotionCount = 2;

		public BaseClass(string name)
		{
			Name = name;
			Health = maxHealth;
			isDefending = false;
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
            if (healPotion > 0)
            {
                int healPoints = 5;
                Health += healPoints;
                healPotion--;
                Console.WriteLine($"\nYou used a heal potion and restored {healPoints} and now at {Health}hp.");
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
    }
}
