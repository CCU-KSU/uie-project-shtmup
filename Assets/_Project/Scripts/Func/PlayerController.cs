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
        [SerializeField] float rollMultiplier = 15.0f;
        [SerializeField] float yawMultiplier = 5.0f;
        [SerializeField]  float leanSpeed = 5.0f;
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

        private bool _useMouseInput;
        private Vector3 _distanceToMove;
        private Vector3 _previousMousePosition;

        void Start()
        {
            input = GetComponent<InputReader>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                _useMouseInput = true;
            }
            else if (Input.anyKeyDown)
            {
                _useMouseInput = false;
            }

            if (_useMouseInput)
            {
                var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;
                _distanceToMove = mousePosition - transform.position;
                _distanceToMove = Vector3.ClampMagnitude(_distanceToMove, (speed * Time.deltaTime));
            }
            else
            {
                _distanceToMove = new Vector3(input.Move.x, input.Move.y, 0.0f) * speed * Time.deltaTime;
            }
            targetPosition += _distanceToMove;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Helpers.QuitGame();
            }

            // targetPosition += new Vector3(input.Move.x, input.Move.y, 0.0f) * speed * Time.deltaTime;

            var minPlayerX = camera.position.x + minX;
            var maxPlayerX = camera.position.x + maxX;
            var minPlayerY = camera.position.y + minY;
            var maxPlayerY = camera.position.y + maxY;

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPlayerX, maxPlayerX);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPlayerY, maxPlayerY);

            // Smoothly move the player to the target position
            if (_useMouseInput)
            {
                transform.position = targetPosition;
            }
            else
            {
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothness);
            }

            var targetRollAngle = _distanceToMove.normalized.x * rollMultiplier;
            var targetYawAngle = -_distanceToMove.normalized.x * yawMultiplier;

            // Smoothly interpolate to the target roll and yaw angles
            var currentRotation = transform.localEulerAngles;
            var targetRotation = new Vector3(
                Mathf.LerpAngle(currentRotation.y, targetRollAngle, leanSpeed * Time.deltaTime),
                0,
                Mathf.LerpAngle(currentRotation.z, targetYawAngle, leanSpeed * Time.deltaTime)
            );

            // Apply the new rotation
            transform.localEulerAngles = targetRotation;
        }
    }
}
