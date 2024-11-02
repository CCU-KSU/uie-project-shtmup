using Eflatun.SceneReference;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shtmup
{
    public class LevelSelectorUI : MonoBehaviour
    {
        [SerializeField] SceneReference mainMenu;
        [SerializeField] Button backToMenu;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        private void Awake()
        {
            backToMenu.onClick.AddListener(() => Loader.Load(mainMenu));
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
