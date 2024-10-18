using Eflatun.SceneReference;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shtmup
{
    public class LevelSelector : MonoBehaviour
    {
        [SerializeField] SceneReference level;
        //public int level;
        // Start is called before the first frame update
        void Start()
        {
        
        }

       public void OpenScene()
       {
            Loader.Load(level);
       }
    }
}
