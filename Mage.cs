using System;


namespace TurnBasedCombatGame
{
    class Mage
    {   
        private Spell currentSpell;
        private double health;


        public string Name {get; private set;}

        public Mage(string name) 
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

        public void Attack(Enemy e) 
        {
            Random r = new Random();
            int damage = r.Next(currentSpell.GetSpellDamage());
            e.TakeDamage(currentSpell.GetSpellDamage());

        }

        public double getHealth()
        {
            return health;
        }

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

        public void TakeDamage(int damage)
        {
            this.health -= damage;
            Console.WriteLine($"You have taken {damage} damage, you are at {this.health}hp.");

            if(this.health <= 0)
            {
                this.health = 0;
                Console.WriteLine("You have died! Game over");
                System.Environment.Exit(1);
            }
        }

        


        //  public void Heal(int addHealth)
        // {
        //     this.health += addHealth;

        //     if(this.health >= 20)
        //     {
        //         this.health = 20;
        //         Console.WriteLine($"You have been healed by {addHealth} hp");
        //     }
        // }

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