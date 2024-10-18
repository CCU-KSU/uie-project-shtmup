using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Shtmup
{
    // Component needed for player movement
    [RequireComponent(typeof(PlayerInput))]
    public class InputReader : MonoBehaviour
    {
        // Reference to player input
        PlayerInput playerInput;
        // Move input
        InputAction moveAction;
        InputAction fireAction;

        // Reads input
        public Vector2 Move => moveAction.ReadValue<Vector2>();
        public bool Fire => fireAction.ReadValue<float>() > 0f;

        void Start()
        {
            playerInput = GetComponent<PlayerInput>();
            moveAction = playerInput.actions["Move"];
            fireAction = playerInput.actions["Fire"];
        }
    }
}
