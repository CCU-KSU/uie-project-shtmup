using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shtmup
{
    public class PlayerHUD : MonoBehaviour
    {
        [SerializeField] Image healthBar;
        [SerializeField] TextMeshProUGUI score;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            healthBar.fillAmount = GameManager.Instance.Player.GetHealthNorm();
            score.text = GameManager.Instance.GetScore().ToString();
        }
    }
}
