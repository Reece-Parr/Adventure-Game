using System;
using System.Reflection.Metadata.Ecma335;
using System.Xml;


namespace TurnBasedCombatGame
{
    public class Mage : Warrior, ICharacter
    {   
        public Spell currentSpell;

        public int hitChance = 75;
        public bool isDefending = false;
        public int healPotion { get; set; } = 2;

        public Mage(string name) : base(name)
        {
            Name = name;   
            this.health = 20;     
            this.currentSpell = new Spell("Fire", 3); 
        }

        public Mage() { }

        // public Spell castFireSpell()
        // {
        //     s = new Spell("Fire", 3, 1);
        //     return s;
        // }

        public string getCurrentSpell() {
           return "Currently wielding: " + currentSpell.GetSpellName() + " | This weapon does: " + currentSpell.GetSpellDamage() + " damage.";
        }

        public void Attack(Enemy e)
        {
            Random rnd = new Random();
            int roll = rnd.Next(1, 101);

            if (roll <= hitChance)
            {
                int damage = currentSpell.GetSpellDamage();
                e.TakeDamage(damage);
            }
            else
            {
                Console.WriteLine("You have missed the enemy!");
            }
        }

        public void TakeDamage(int damage)
        {
            this.health -= damage;
            Console.WriteLine($"The player has taken {damage} damage, and is now at {this.health}hp");

            if (this.health <= 0)
            {
                this.health = 0;
                Console.WriteLine("You have been killed!");
                // Either end game or Load a recent save - not yet implemented recent save feature.
                // PLEASE COME BACK TO THIS AFTER COMBAT IS TESTED
            }
        }

        public bool UseHealPotion()
        {
            if (healPotion > 0)
            {
                int healPoints = 5;
                this.health += healPoints;
                healPotion--;
                Console.WriteLine($"\nYou used a heal potion and restored {healPoints} and now at {this.health}hp.");
                return true;
            }
            else
            {
                Console.WriteLine("You are out of healing potions!");
                return false;
            }
        }

        public override string ToString()
        {
            return $"Current Player: \n" +
            "Name: " + Name + "\n" + 
            "Health: " + getHealth() + "\n" +
            "Class: Mage" + "\n" + getCurrentSpell();
        }

        // public string getEquipped(string c) 
        // {
        //     Class = c;

        //     if(Class == "Warrior")
        //     {
        //         return "Currently wielding: " + currentWeapon.GetWeaponName() + " | This weapon does: " + currentWeapon.GetWeaponDamage() + " damage.";
        //     }
        //     else if(Class == "Mage")
        //     {
        //         return "Currently wielding: " + currentSpell.GetSpellName() + " | This weapon does: " + currentSpell.GetSpellDamage() + " damage.";
        //     }
        //     else
        //     {
        //         return "Class not recognized";
        //     }
        // }


    }
}