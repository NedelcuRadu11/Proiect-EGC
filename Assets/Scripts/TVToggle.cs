using UnityEngine;
using UnityEngine.InputSystem;

public class TVToggle : MonoBehaviour
{
    public Material tvOnMaterial;
    public Material tvOffMaterial;

    private bool isOn = true;
    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = tvOnMaterial;
    }

    void Update()
    {
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            isOn = !isOn;
            meshRenderer.material = isOn ? tvOnMaterial : tvOffMaterial;
        }
    }
}
