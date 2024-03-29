using System;


namespace TurnBasedCombatGame
{
    public class Weapon 
    {   
        public string WeaponName { get; set; }

        public int WeaponDamage { get; set; }

        public Weapon(string name, int damage) {
            WeaponName = name;
            WeaponDamage = damage;
        }
        public Weapon() { } 

        public string GetWeaponName() {
            return WeaponName;
        }

        public int GetWeaponDamage() {
            return WeaponDamage;
        }
    }
}