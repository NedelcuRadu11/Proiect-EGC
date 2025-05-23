using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 10f;
    public Transform playerBody;

    private PlayerControls controls;
    private Vector2 lookInput;
    private float xRotation = 0f;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        controls.Player.Look.canceled += _ => lookInput = Vector2.zero;
    }

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Blochează cursorul în centru
        Cursor.visible = false;                    // Ascunde cursorul
    }

    void Update()
    {
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
