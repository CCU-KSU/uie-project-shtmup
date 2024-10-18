using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shtmup
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected WeaponStrategy weaponStrategy;
        [SerializeField] protected Transform firePoint;
        [SerializeField, Layer] protected int layer;

        private void OnValidate()
        {
            layer = gameObject.layer;
        }

        // Start is called before the first frame update
        void Start()
        {
            weaponStrategy.Initialize();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void SetWeaponStrategy(WeaponStrategy strategy)
        {
            weaponStrategy = strategy;
            weaponStrategy.Initialize();
        }
    }
}
