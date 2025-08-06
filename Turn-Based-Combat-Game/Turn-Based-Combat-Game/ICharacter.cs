using System;

namespace TurnBasedCombatGame
{
    public interface ICharacter
    {
        void Attack(Enemy enemy);
        bool UseHealPotion();
        bool isDefending { get; set; }
        int Health { get; set; }

        public string GetName();
    }
}