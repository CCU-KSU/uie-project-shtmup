using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace Shtmup
{
    public class EnemyBuilder
    {
        GameObject enemyPrefab;
        SplineContainer spline;
        GameObject weaponPrefab;
        float speed;
        
        public EnemyBuilder SetBasePrefab( GameObject prefab)
        {
            enemyPrefab = prefab;
            return this;
        }

        public EnemyBuilder SetSplinePrefab( SplineContainer spline )
        {
            this.spline = spline;
            return this;
        }

        public EnemyBuilder SetWeaponPrefab( GameObject prefab)
        {
            weaponPrefab = prefab;
            return this;   
        }

        public EnemyBuilder SetSpeed( float speed )
        {
            this.speed = speed;
            return this;
        }

        public GameObject Build()
        {
            GameObject instance = GameObject.Instantiate(enemyPrefab);

            SplineAnimate splineAnimate = instance.GetORAdd<SplineAnimate>();
            splineAnimate.Container = spline;
            splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
            splineAnimate.ObjectUpAxis = SplineAnimate.AlignAxis.ZAxis;
            splineAnimate.ObjectForwardAxis = SplineAnimate.AlignAxis.YAxis;
            splineAnimate.Alignment = SplineAnimate.AlignmentMode.SplineElement;
            splineAnimate.MaxSpeed = speed;
            splineAnimate.Restart(true);

            //Weapons Here

            instance.transform.position = spline.EvaluatePosition(0f);

            return instance;
        }
    }
}
