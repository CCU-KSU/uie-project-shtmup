using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shtmup
{
    public abstract class Plane : MonoBehaviour
    {
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] int maxHealth;
        private int health;

        protected virtual void Awake()
        {
            health = maxHealth;
            //spriteRenderer = GetComponent<SpriteRenderer>();
        }
        public void SetMaxHealth(int amount) => maxHealth = amount;

        public void TakeDamage(int amount)
        {
            health -= amount;
            HitFlash();
            if (health <= 0)
            {
                Die(0);
            }
            //Color temp = spriteRenderer.color;
            //temp.a = 130f;


        }

        void HitFlash()
        {
            StartCoroutine(Flashing());
        }

        IEnumerator Flashing()
        {
            Debug.Log(spriteRenderer);
            int flashes = 3;
            while (flashes > 0)
            {
                spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
                yield return null;
                spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
                yield return new WaitForSeconds(0.035f);
                yield return null;
                flashes--;
            }
        }

        public float GetHealthNorm() => ((float)health / (float)maxHealth);

        //Cause of death
        // 0 -> depleted health
        // 3 -> end of path
        protected abstract void Die(int cause);
    }
}
