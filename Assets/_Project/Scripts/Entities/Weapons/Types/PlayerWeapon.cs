using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Shtmup
{
    public class PlayerWeapon : Weapon
    {
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
            }
        }
    }
}
