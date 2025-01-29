using UnityEngine;
using NRKernal;
using System.Collections;

public class HouseMover : MonoBehaviour
{
    [SerializeField] private GameObject cameraRig;

    public Transform houseTransform; // The Transform of the house to move
    public float moveSpeed = 1.0f; // Speed of movement

    public bool isHouseLocked = false;

    private Vector2 touchpadPosition; // Current touchpad position
    private bool isTouchpadPressed; // Whether the touchpad is pressed

    void Update()
    {
        if (isHouseLocked) return; // available only when house is not locked

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

        float cameraAngleY = cameraRig.transform.rotation.eulerAngles.y;
        moveDirection = new Vector3(Mathf.Cos(cameraAngleY * Mathf.Deg2Rad) * moveDirection.x + Mathf.Sin(cameraAngleY * Mathf.Deg2Rad) * moveDirection.z,
                                    0,
                                    Mathf.Cos(cameraAngleY * Mathf.Deg2Rad) * moveDirection.z - Mathf.Sin(cameraAngleY * Mathf.Deg2Rad) * moveDirection.x);

        // Apply movement
        houseTransform.position += moveSpeed * Time.deltaTime * moveDirection;
    }

    private void MoveHouse(Vector2 input)
    {
        // Calculate movement direction based on touchpad input
        float cameraAngleY = cameraRig.transform.rotation.eulerAngles.y;
        Vector3 moveDirection = new Vector3(Mathf.Cos(cameraAngleY * Mathf.Deg2Rad) * input.x + Mathf.Sin(cameraAngleY * Mathf.Deg2Rad) * input.y, 
                                            0, 
                                            Mathf.Cos(cameraAngleY * Mathf.Deg2Rad) * input.y - Mathf.Sin(cameraAngleY * Mathf.Deg2Rad) * input.x);

        // Apply movement to the house
        houseTransform.position += moveSpeed * Time.deltaTime * moveDirection;
    }
}
