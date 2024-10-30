using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shtmup
{
    [CreateAssetMenu(menuName = "Create SigleShot", fileName = "Shtmup/WeaponStrategy/SingleShot", order = 0)]
    public class SingleShot : WeaponStrategy
    {
        public override void Fire(Transform firePoint, LayerMask layer)
        {
            var projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            projectile.transform.SetParent(firePoint);
            projectile.layer = layer;

            var projectileComponent = projectile.GetComponent<Projectile>();
            projectileComponent.SetSpeed(projectileSpeed);
            projectileComponent.SetDamage(damage);
            Destroy(projectile, projectileLifetime);
        }
    }
}
