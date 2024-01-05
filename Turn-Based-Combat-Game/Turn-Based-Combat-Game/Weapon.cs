using System;


namespace TurnBasedCombatGame
{
    class Weapon 
    {   
        private string WeaponName { get; set; }

        private int WeaponDamage { get; set; }

        public Weapon(string name, int damage) {
            WeaponName = name;
            WeaponDamage = damage;
        }

        public string GetWeaponName() {
            return WeaponName;
        }

        public int GetWeaponDamage() {
            return WeaponDamage;
        }
    }
}