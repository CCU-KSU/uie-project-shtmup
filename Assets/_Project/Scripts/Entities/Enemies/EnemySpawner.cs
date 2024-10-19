using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace Shtmup
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] List<EnemyType> enemyTypes;
        [SerializeField] int maxEnemies = 10;
        [SerializeField] float spawnInterval = 1.0f;
        [SerializeField] int EnemyTypeSeed;
        [SerializeField] int PatheSeed;
        [SerializeField] float graceTime = 5.0f;
        bool grace = true;

        List<SplineContainer> splines;
        EnemyFactory enemyFactory;

        System.Random randEnemyType;
        System.Random randSpline;

        float spawnTimer;
        int enemiesSpawned;

        //private void OnValidate()
        //{
        //    splines = new List<SplineContainer>(GetComponentsInChildren<SplineContainer>());
        //}
        // Start is called before the first frame update
        void Start()
        {
            splines = new List<SplineContainer>(GetComponentsInChildren<SplineContainer>());
            enemyFactory = new EnemyFactory();
            randEnemyType = new System.Random(EnemyTypeSeed);
            randSpline = new System.Random(PatheSeed);
        }

        // Update is called once per frame
        void Update()
        {
            if (grace)
            {
                if (graceTime > 0f)
                {
                    graceTime -= Time.deltaTime;
                }
                else
                {
                    grace = false;
                }
                
            }

            spawnTimer += Time.deltaTime;
            if (grace != true && GameManager.Instance.GetEnemyCount() < maxEnemies && spawnTimer >= spawnInterval && GameManager.Instance.GetEnemyPool() > 0)
            {
                SpawnEnemy();
                spawnTimer = 0f;
                GameManager.Instance.EnemyPool(-1);
            }

            //if (enemiesSpawned < maxEnemies && spawnTimer >= spawnInterval)
            //{
            //    SpawnEnemy();
            //    spawnTimer = 0f;

            //}
        }

        void SpawnEnemy()
        {
            //Debug.Log("Spawned");
            //Debug.LogError("Spawned");
            //Debug.Log(splines);

            //EnemyType enemyType = enemyTypes[UnityEngine.Random.Range(0, enemyTypes.Count)];
            //SplineContainer spline = splines[UnityEngine.Random.Range(0, splines.Count)];

            EnemyType enemyType = enemyTypes[randEnemyType.Next(0, enemyTypes.Count)];
            SplineContainer spline = splines[randSpline.Next(0, splines.Count)];

            //Debug.Log(spline);
            //Debug.Log(enemyType);

            enemyFactory.CreateEnemy(enemyType, spline);

            //enemiesSpawned++;
            GameManager.Instance.EnemyCount(1);
        }
    }
}
