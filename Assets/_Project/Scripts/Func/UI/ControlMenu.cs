using Eflatun.SceneReference;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shtmup
{
    public class ControlMenu : MonoBehaviour
    {
        [SerializeField] SceneReference mainMenu;
		[SerializeField] Button btnMenu;

        private void Awake()
        {
            btnMenu.onClick.AddListener(() => Loader.Load(mainMenu));
            Time.timeScale = 1.0f;
        }
    }
}
