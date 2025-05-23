using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 50, 0); // Grade/sec

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
