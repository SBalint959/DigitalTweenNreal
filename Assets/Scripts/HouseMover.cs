using UnityEngine;
using NRKernal;

public class HouseMover : MonoBehaviour
{
    public Transform houseTransform; // The Transform of the house to move
    public float moveSpeed = 1.0f; // Speed of movement

    private Vector2 touchpadPosition; // Current touchpad position
    private bool isTouchpadPressed; // Whether the touchpad is pressed

    void Update()
    {
        // Check for input from the Nreal controller
        HandleControllerInput();

        // Check for input from the custom keyboard controls
        HandleCustomKeyboardInput();
    }

    private void HandleControllerInput()
    {
        // Check if the controller is available
        if (NRInput.CheckControllerAvailable(ControllerHandEnum.Right))
        {
            // Get touchpad position and press state
            touchpadPosition = NRInput.GetTouch();
            isTouchpadPressed = NRInput.GetButton(ControllerButton.TRIGGER);

            // Move the house if the touchpad is being pressed
            if (isTouchpadPressed)
            {
                MoveHouse(touchpadPosition);
            }
        }
        if (NRInput.GetButton(ControllerButton.APP)) {
            houseTransform.Rotate(Vector3.up, 90 * Time.deltaTime);
        }
}

    private void HandleCustomKeyboardInput()
    {
        Vector3 moveDirection = Vector3.zero;

        // Use U, H, J, L keys for moving the house
        if (Input.GetKey(KeyCode.U)) // Up
        {
            moveDirection += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.J)) // Down
        {
            moveDirection += Vector3.back;
        }
        if (Input.GetKey(KeyCode.H)) // Left
        {
            moveDirection += Vector3.left;
        }
        if (Input.GetKey(KeyCode.K)) // Right
        {
            moveDirection += Vector3.right;
        }

        if (Input.GetKey(KeyCode.Q) || NRInput.GetButton(ControllerButton.APP))
        {
            houseTransform.Rotate(Vector3.up, 90 * Time.deltaTime);
        }


        // Apply movement
        houseTransform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    private void MoveHouse(Vector2 input)
    {
        // Calculate movement direction based on touchpad input
        Vector3 moveDirection = new Vector3(input.x, 0, input.y);

        // Apply movement to the house
        houseTransform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
