using System;
using System.Reflection.Metadata.Ecma335;
using System.Xml;


namespace TurnBasedCombatGame
{
    public class Mage : BaseClass
    {   
        public Spell currentSpell;

        public int hitChance = 75;
        public bool isDefending = false;
        public int healPotion { get; set; } = 2;

        public Mage(string name) : base(name)
        {
            this.currentSpell = new Spell("Fire", 3); 
        }

        // public Spell castFireSpell()
        // {
        //     s = new Spell("Fire", 3, 1);
        //     return s;
        // }

        public string getCurrentSpell() {
           return "Currently wielding: " + currentSpell.GetSpellName() + " | This weapon does: " + currentSpell.GetSpellDamage() + " damage.";
        }

        public override void Attack(Enemy e)
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

        public override string ToString()
        {
            return $"Current Player: \n" +
            "Name: " + GetName() + "\n" + 
            "Health: " + GetHealth() + "\n" +
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