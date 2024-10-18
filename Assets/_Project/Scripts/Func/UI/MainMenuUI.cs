using Eflatun.SceneReference;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shtmup
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] SceneReference startingLevel;
        [SerializeField] Button btnPlay;
        [SerializeField] Button btnQuit;

        private void Awake()
        {
            btnPlay.onClick.AddListener(() => Loader.Load(startingLevel));
            btnQuit.onClick.AddListener(() => Helpers.QuitGame()); // Not in editor
            //btnQuit.onClick.AddListener(() => Application.Quit());
            Time.timeScale = 1.0f;
        }
    }
}
