using System;


namespace TurnBasedCombatGame
{
    public class Spell
    {   
        public string SpellName { get; set; }

        public int SpellDamage { get; set; }
        
        public Spell(string name, int damage) {
            SpellName = name;
            SpellDamage = damage;
        }

        public Spell() { }

        public string GetSpellName() {
            return SpellName;
        }

        public int GetSpellDamage() {
            return SpellDamage;
        }
    }
}