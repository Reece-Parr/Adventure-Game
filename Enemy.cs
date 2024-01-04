using System;
using System.Reflection.Metadata.Ecma335;

namespace TurnBasedCombatGame
{
    class Enemy : ICombat
    {
        
        private int EnemyHealth { get; set; }
  
        public Enemy(int health)
        {
            EnemyHealth = health;
        }
        public void TakeDamage(int damage)
        {
            EnemyHealth -= damage;
            Console.WriteLine($"The enemy has taken {damage} damage, and is now at {EnemyHealth}hp");

            if(EnemyHealth <= 0)
            {
                EnemyHealth = 0;
                Console.WriteLine("Enemy killed!");
            }
        }

        public void Attack(Mage m) {
            Random r = new Random();
            int damage = r.Next(4);
            m.TakeDamage(damage);
        }

        public override string ToString()
        {
            return $"Enemy current health: {EnemyHealth}";
        }
    }
}