using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shtmup
{
    public class ParallaxController : MonoBehaviour
    {
        [SerializeField] float paraSpeed;
        [SerializeField] bool scrollVirt;

        private float singleTectureHeight;
        // Start is called before the first frame update
        void Start()
        {
            SetupTexture();
        }

        private void SetupTexture()
        {
            Sprite sprite = GetComponent<SpriteRenderer>().sprite;
            singleTectureHeight = sprite.texture.height / sprite.pixelsPerUnit;
        }

        private void Scroll()
        {
            float delta = paraSpeed * Time.deltaTime;
            transform.position -= new Vector3(0f, delta, 0f);
        }

        private void CheckAndReset()
        {
            if ((Mathf.Abs(transform.position.y) - singleTectureHeight) > 0)
            {
                transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
            }
        }

        // Update is called once per frame
        void Update()
        {
            Scroll();
            CheckAndReset();
        }
    }
}
