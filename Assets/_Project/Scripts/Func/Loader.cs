using Eflatun.SceneReference;
using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shtmup
{
    public static class Loader
    {
        static SceneReference loadingScene = new(SceneGuidToPathMapProvider.ScenePathToGuidMap["Assets/_Project/Scenes/Loading.unity"]);
        static SceneReference targetScene;
        public static void Load(SceneReference sceneReference)
        {
            targetScene = sceneReference;
            SceneManager.LoadScene("Loading");
            Timing.RunCoroutine(LoadTargetScene());
        }

        private static IEnumerator<float> LoadTargetScene()
        {
            yield return Timing.WaitForOneFrame;
            SceneManager.LoadScene(targetScene.Name);
        }
    }
}
