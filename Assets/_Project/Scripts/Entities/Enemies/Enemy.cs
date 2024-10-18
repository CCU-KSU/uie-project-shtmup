using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace Shtmup
{
    public class Enemy : Plane
    {
        [SerializeField] SplineAnimate splineAnimate;
        protected override void Die(int cause)
        {
            if (cause == 0)
            {
                GameManager.Instance.AddScore(10);
            }
            GameManager.Instance.EnemyCount(-1);
            //GameManager.Instance.EnemyPool(-1);
            Destroy(gameObject);
        }

        private void Update()
        {
            //Debug.Log(Math.Round(splineAnimate.NormalizedTime, 1));
            if (Math.Round(splineAnimate.NormalizedTime, 1) >= 1.0f)
            {
                //Debug.Log("Looped");
                Die(3);
                //enabled = false;
            }
        }
        protected void DieOnEnd()
        {

        }
    }
}
