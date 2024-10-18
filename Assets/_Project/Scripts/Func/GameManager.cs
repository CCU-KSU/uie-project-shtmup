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
        public static GameManager Instance { get; private set; }
        public Player Player => player;
        Player player;

        //Personal
        bool objectiveComplete = false;
        //Use objective objects


        private int score;
        float restartTimer = 3f;


        public bool IsGameOver() => player.GetHealthNorm() <= 0 || objectiveComplete;

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
                restartTimer -= Time.deltaTime;

                if (gameOverUI != null && gameOverUI.activeSelf == false)
                {
                    gameOverUI.SetActive(true);
                }

                if (restartTimer <= 0)
                {
                    Loader.Load(mainMenuScene);
                }
            }
        }

        public void AddScore(int amount) => score += amount;

        public int GetScore() => score;
    }
}
