using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shtmup
{
    public class EnemyWeapon : Weapon
    {
        float fireTimer;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            fireTimer += Time.deltaTime;

            if (fireTimer >= weaponStrategy.FireRate)
            {
                weaponStrategy.Fire(firePoint, layer);
                fireTimer = 0f;
            }
        }
    }
}
