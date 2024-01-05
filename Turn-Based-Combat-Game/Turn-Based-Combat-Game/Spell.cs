using System;


namespace TurnBasedCombatGame
{
    class Spell
    {   
        private string SpellType { get; set; }

        private int SpellDamage { get; set; }
        
        public Spell(string name, int damage) {
            SpellType = name;
            SpellDamage = damage;
        }

        public string GetSpellName() {
            return SpellType;
        }

        public int GetSpellDamage() {
            return SpellDamage;
        }
    }
}