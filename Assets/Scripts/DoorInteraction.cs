using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public Transform pivot;         // Aici setezi Empty-ul care va fi pivotul
    public bool isOpen = false;
    public float openAngle = 90f;
    public float speed = 2f;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        if (pivot == null) pivot = transform;

        closedRotation = pivot.rotation;
        openRotation = Quaternion.Euler(pivot.eulerAngles + new Vector3(0f, openAngle, 0f));
    }

    void Update()
    {
        Quaternion targetRotation = isOpen ? openRotation : closedRotation;
        pivot.rotation = Quaternion.Lerp(pivot.rotation, targetRotation, Time.deltaTime * speed);
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
    }
}
