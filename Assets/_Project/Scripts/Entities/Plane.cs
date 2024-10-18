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
                Die();
            }
        }


        public float GetHealthNorm() => ((float)health / (float)maxHealth);

        protected abstract void Die();
    }
}
