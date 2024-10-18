using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Shtmup
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float speed = 5f;
        [SerializeField] float smoothness = 0.1f;
        [SerializeField] GameObject model;
        [Header("Camera Bounds")]
        [SerializeField] Transform camera;
        [SerializeField] float minX = -8f;
        [SerializeField] float maxX = 8f;
        [SerializeField] float minY = -8f;
        [SerializeField] float maxY = 8f;

        InputReader input;
        Vector3 targetPosition;
        Vector3 currentVelocity;

        

        void Start()
        {
            input = GetComponent<InputReader>();
        }

        private void Update()
        {
            targetPosition += new Vector3(input.Move.x, input.Move.y, 0.0f) * speed * Time.deltaTime;

            var minPlayerX = camera.position.x + minX;
            var maxPlayerX = camera.position.x + maxX;
            var minPlayerY = camera.position.y + minY;
            var maxPlayerY = camera.position.y + maxY;

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPlayerX, maxPlayerX);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPlayerY, maxPlayerY);

            //Debug.Log(targetPosition.x);
            //Debug.Log(targetPosition.y);

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothness);
        }
    }
}
