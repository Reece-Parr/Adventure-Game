using System;


namespace TurnBasedCombatGame
{
    class Mage : Warrior, ICharacter
    {   
        private Spell currentSpell;
        private double health;

        public Mage(string name) : base(name)
        {
            Name = name;   
            this.health = 20;     
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