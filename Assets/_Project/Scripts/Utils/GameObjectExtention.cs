using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shtmup
{
    public static class GameObjectExtention
    {
        public static T GetORAdd<T>(this GameObject gameObject) where T : Component
        {
            T component = gameObject.GetComponent<T>();
            return component != null ? component : gameObject.AddComponent<T>();
        }
    }
}
