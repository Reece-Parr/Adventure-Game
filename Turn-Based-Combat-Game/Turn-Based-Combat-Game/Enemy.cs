using System;
using System.Reflection.Metadata.Ecma335;

namespace TurnBasedCombatGame
{
    public class Enemy : ICombat
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
            int damage = r.Next(0, 4);

            if (damage < 0)
            {
                Console.WriteLine("Enemy has missed.");
            }
            else
            {
                m.TakeDamage(damage);
            }
        }

        public int GetHealth()
        {
            return EnemyHealth;
        }

        public override string ToString()
        {
            return $"Enemy current health: {EnemyHealth}";
        }
    }
}