using System;


namespace TurnBasedCombatGame
{
    class Warrior : ICharacter
    {   
        private Weapon currentWeapon;
        private double health;


        public string Name {get; protected set;}

        public Warrior(string name) 
        {
            Name = name;   
            this.health = 20;     
            this.currentWeapon = new Weapon("Longsword", 3); 
        }

        public void Attack(Enemy e) 
        {
            Random r = new Random();
            int damage = r.Next(currentWeapon.GetWeaponDamage());
            e.TakeDamage(currentWeapon.GetWeaponDamage());

        }

        public string GetName() {
            return Name;
        }

        public double getHealth()
        {
            return health;
        }

        public string getCurrentWeapon() {
           return "Currently wielding: " + currentWeapon.GetWeaponName() + " | This weapon does: " + currentWeapon.GetWeaponDamage() + " damage.";
        }

        public override string ToString()
        {
            return $"Current Player: \n" +
            "Name: " + Name + "\n" + 
            "Health: " + getHealth() + "\n" +
            "Class: Warrior" + "\n" + getCurrentWeapon();
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