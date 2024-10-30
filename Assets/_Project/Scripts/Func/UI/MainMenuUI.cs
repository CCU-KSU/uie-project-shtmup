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
		[SerializeField] SceneReference controlMenu;
        [SerializeField] Button btnPlay;
        [SerializeField] Button btnQuit;
		[SerializeField] Button btnCntrl;

        private void Awake()
        {
            btnPlay.onClick.AddListener(() => Loader.Load(startingLevel));
            btnQuit.onClick.AddListener(() => Helpers.QuitGame()); // Not in editor
            //btnQuit.onClick.AddListener(() => Application.Quit());
			btnCntrl.onClick.AddListener(() => Loader.Load(controlMenu));
            Time.timeScale = 1.0f;
        }
    }
}
