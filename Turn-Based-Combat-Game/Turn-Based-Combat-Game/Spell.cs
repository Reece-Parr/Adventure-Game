using System;


namespace TurnBasedCombatGame
{
    class Spell
    {   
        private string SpellName { get; set; }

        private int SpellDamage { get; set; }
        
        public Spell(string name, int damage) {
            SpellName = name;
            SpellDamage = damage;
        }

        public string GetSpellName() {
            return SpellName;
        }

        public int GetSpellDamage() {
            return SpellDamage;
        }
    }
}