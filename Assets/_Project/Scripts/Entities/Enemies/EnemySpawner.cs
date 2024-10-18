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

        List<SplineContainer> splines;
        EnemyFactory enemyFactory;

        float spawnTimer;
        int enemiesSpawned;

        private void OnValidate()
        {
            splines = new List<SplineContainer>(GetComponentsInChildren<SplineContainer>());
        }
        // Start is called before the first frame update
        void Start()
        {
            enemyFactory = new EnemyFactory();
        }

        // Update is called once per frame
        void Update()
        {
            spawnTimer += Time.deltaTime;
            if (enemiesSpawned < maxEnemies && spawnTimer >= spawnInterval)
            {
                SpawnEnemy();
                spawnTimer = 0f;
            }
        }

        void SpawnEnemy()
        {
            EnemyType enemyType = enemyTypes[UnityEngine.Random.Range(0, enemyTypes.Count)];
            SplineContainer spline = splines[UnityEngine.Random.Range(0, splines.Count)];

            //Debug.Log(spline);
            //Debug.Log(enemyType);

            enemyFactory.CreateEnemy(enemyType, spline);

            enemiesSpawned++;
        }
    }
}
