using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shtmup
{
    [CreateAssetMenu(fileName = "EnemyType", menuName = "Shtmup/EnemyType", order = 0)]
    public class EnemyType : ScriptableObject
    {
        public GameObject enemyPrefab;
        public GameObject weaponPrefab;
        public float speed;
    }
}
