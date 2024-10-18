using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace Shtmup
{
    public class EnemyFactory
    {
        public GameObject CreateEnemy(EnemyType enemyType, SplineContainer spline)
        {
            EnemyBuilder builder = new EnemyBuilder()
                .SetBasePrefab(enemyType.enemyPrefab)
                .SetSplinePrefab(spline)
                .SetSpeed(enemyType.speed);
            //Weapons

            return builder.Build();
        }
    }
}
