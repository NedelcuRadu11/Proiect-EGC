using UnityEngine;
using UnityEngine.InputSystem;

public class DoorInteractor : MonoBehaviour
{
    public float interactDistance = 3f;

    private PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Interact.performed += ctx => Interact();
    }

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();

    private void Interact()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            // Verifică și pe obiectul lovit, și pe părintele lui
            DoorInteraction door = hit.collider.GetComponent<DoorInteraction>() 
                                ?? hit.collider.GetComponentInParent<DoorInteraction>();

            if (door != null)
            {
                door.ToggleDoor();
            }
        }
    }
}
