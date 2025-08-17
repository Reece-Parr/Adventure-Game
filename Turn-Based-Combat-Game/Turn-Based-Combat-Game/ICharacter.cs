using System;

namespace TurnBasedCombatGame
{
    public interface ICharacter
    {
        void Attack(Enemy enemy);
        bool UseHealPotion();
        bool isDefending { get; set; }
        int Health { get; set; }
        void TakeDamage(int damage);
        Inventory inventory { get; }

        public string GetName();
        public int GetHealth();
    }
}