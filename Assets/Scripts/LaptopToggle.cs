using UnityEngine;
using UnityEngine.InputSystem;

public class LaptopToggle : MonoBehaviour
{
    public Material laptopOnMaterial;
    public Material laptopOffMaterial;

    private bool isOn = true;
    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = laptopOnMaterial;
    }

    void Update()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            isOn = !isOn;
            meshRenderer.material = isOn ? laptopOnMaterial : laptopOffMaterial;
        }
    }
}
