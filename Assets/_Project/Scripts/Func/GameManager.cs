using Eflatun.SceneReference;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shtmup
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] SceneReference mainMenuScene;
        [SerializeField] GameObject gameOverUI;
        [SerializeField] GameObject playerObj;
        [SerializeField] int enemyPool = 50;
        public static GameManager Instance { get; private set; }
        public Player Player => player;
        Player player;

        //Personal
        bool objectiveComplete = false;
        int activeEnenmies = 0;
        //Use objective objects


        private int score;
        float restartTimer = 3f;


        public bool IsGameOver() => player.GetHealthNorm() <= 0 || (enemyPool <= 0 && activeEnenmies <= 0);

        private void Awake()
        {
            Instance = this;

            //Debug.Log(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>());
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        private void Update()
        {
            if (IsGameOver())
            {
                //restartTimer -= Time.deltaTime;

                if (gameOverUI != null && gameOverUI.activeSelf == false)
                {
                    gameOverUI.SetActive(true);
                    playerObj.SetActive(false);
                }

                //if (restartTimer <= 0)
                //{
                //    Loader.Load(mainMenuScene);
                //}
            }
        }

        public void AddScore(int amount) => score += amount;

        public void EnemyCount(int mod)
        {
            activeEnenmies += mod;
        }

        public void EnemyPool(int mod)
        {
            enemyPool += mod;
        }

        public int GetEnemyCount() => activeEnenmies;

        public int GetEnemyPool() => enemyPool;

        public int GetScore() => score;
    }
}
