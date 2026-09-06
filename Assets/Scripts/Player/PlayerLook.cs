using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    public float sensitivity = 2f;
    public InputAction lookAction;

    public Transform cameraTransform;

    private float cameraRotationX = 0f;

    void Start()
    {
        lookAction.Enable();
    }

    void Update()
    {
        Look();
    }

    void Look()
    {
        Vector2 input = lookAction.ReadValue<Vector2>();

        float mouseX = input.x * sensitivity * 0.01f;
        float mouseY = input.y * sensitivity * 0.01f;

        // Player xoay trái / phải
        transform.Rotate(Vector3.up * mouseX);

        // Camera nhìn lên / xuống
        cameraRotationX -= mouseY;
        cameraRotationX = Mathf.Clamp(cameraRotationX, -90f, 90f);

        cameraTransform.localRotation =
            Quaternion.Euler(cameraRotationX, 0f, 0f);
    }

    void OnDestroy()
    {
        lookAction.Disable();
    }
}