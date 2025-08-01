using System;
using System.Xml;


namespace TurnBasedCombatGame
{
    public class Mage : Warrior, ICharacter
    {   
        public Spell currentSpell;

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
            Random rng = new Random();
            double modifier = rng.NextDouble() * 0.4 + 0.8;
            int damage = (int)Math.Round(currentSpell.SpellDamage * modifier);

            if (damage < 0)
            {
                Console.WriteLine("You have missed the enemy!");
            }
            e.TakeDamage(damage);
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