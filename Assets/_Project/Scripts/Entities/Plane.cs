using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shtmup
{
    public abstract class Plane : MonoBehaviour
    {
        [SerializeField] int maxHealth;
        private int health;

        protected virtual void Awake() => health = maxHealth;
        public void SetMaxHealth(int amount) => maxHealth = amount;

        public void TakeDamage(int amount)
        {
            health -= amount;
            if (health <= 0)
            {
                Die(0);
            }
        }


        public float GetHealthNorm() => ((float)health / (float)maxHealth);

        //Cause of death
        // 0 -> depleted health
        // 3 -> end of path
        protected abstract void Die(int cause);
    }
}
