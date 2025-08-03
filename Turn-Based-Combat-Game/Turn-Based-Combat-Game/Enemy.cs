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
            Console.WriteLine($"\nThe enemy has taken {damage} damage, and is now at {EnemyHealth}hp");

            if(EnemyHealth <= 0)
            {
                EnemyHealth = 0;
                Console.WriteLine("\nEnemy killed!");
            }
        }

        public void Attack(Mage m) 
        {
            Random r = new Random();
            int damage = r.Next(0, 5);
            bool checkSuccessfulDefence = new Random().Next(0, 2) == 1;
            bool reduceDamage = false;

            Console.WriteLine($"Incoming damage before defence: {damage}");

            if (damage == 0)
            {
                Console.WriteLine("Enemy has missed!");
            }
            else
            {
                if (m.isDefending && checkSuccessfulDefence)
                {
                    damage /= 2;

                    if (damage <= 0)
                    {
                        Console.WriteLine("\nYou completely blocked the attack!");
                    }
                    else
                    {
                        Console.WriteLine("\nYou blocked the attack! Damage reduced.");
                        m.TakeDamage(damage);
                    }
                }
                else
                {
                    if (m.isDefending)
                    {
                        Console.WriteLine("\nYou tried to defend, but failed!");
                    }

                    m.TakeDamage(damage);
                }
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