using System;


namespace TurnBasedCombatGame
{
    [Serializable]
    public class Warrior : BaseClass
    {   
        public Weapon currentWeapon;

        public int hitChance = 75;
        public bool isDefending = false;
        public int healPotion { get; set; } = 2;

        public Warrior(string name) : base (name)
        {  
            this.currentWeapon = new Weapon("Longsword", 3);
            inventory.AddItem("Healing Potion", 2);
        }

        public override void Attack(Enemy e)
        {
            Random rnd = new Random();
            int roll = rnd.Next(1, 101);

            if (roll <= hitChance)
            {
                int damage = currentWeapon.GetWeaponDamage();
                e.TakeDamage(damage);
            }
            else
            {
                Console.WriteLine("You have missed the enemy!");
            }
        }

        public string getCurrentWeapon() {
           return "Currently wielding: " + currentWeapon.GetWeaponName() + " | This weapon does: " + currentWeapon.GetWeaponDamage() + " damage.";
        }

        public override string ToString()
        {
            return $"Current Player: \n" +
            "Name: " + Name + "\n" + 
            "Health: " + GetHealth() + "\n" +
            "Class: Warrior" + "\n" + getCurrentWeapon();
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