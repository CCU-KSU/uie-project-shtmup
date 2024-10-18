using Eflatun.SceneReference;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shtmup
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] SceneReference mainMenu;
        [SerializeField] Button backToMenu;
        [SerializeField] TextMeshProUGUI score;
        [SerializeField] TextMeshProUGUI health;

        private void Awake()
        {
            backToMenu.onClick.AddListener(() => Loader.Load(mainMenu));
            score.text += GameManager.Instance.GetScore().ToString();
            health.text += ((GameManager.Instance.Player.GetHealthNorm() * 100).ToString() + "%");
            //btnQuit.onClick.AddListener(() => Application.Quit());
            Time.timeScale = 1.0f;
        }
    }
}
