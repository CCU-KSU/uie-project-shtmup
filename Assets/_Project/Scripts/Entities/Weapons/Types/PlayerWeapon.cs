using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shtmup
{
    public class PlayerWeapon : Weapon
    {
        [SerializeField] AudioSource audioSource;
        InputReader input;
        float fireTimer;

        private void Awake()
        {
            input = GetComponent<InputReader>();
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            fireTimer += Time.deltaTime;

            if (input.Fire && fireTimer >= weaponStrategy.FireRate)
            {
                weaponStrategy.Fire(firePoint, layer);
                fireTimer = 0f;
                audioSource.Play();
            }
        }
    }
}
