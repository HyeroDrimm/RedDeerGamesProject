// By Wojciech "HyeroDrimm" Wroński

using UnityEngine;

[RequireComponent(typeof(BulletToggle))]
[RequireComponent(typeof(MeshRenderer))]
public class ToggleMaterialChange : MonoBehaviour
{
    [SerializeField] private Material onMaterial;
    [SerializeField] private Material offMaterial;

    private BulletToggle toggle;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        toggle = GetComponent<BulletToggle>();
        meshRenderer = GetComponent<MeshRenderer>();


        toggle.secretOnButtonTurnOn += SetOnMaterial;
        toggle.secretOnButtonTurnOff += SetOffMaterial;

        if (toggle.currentState)
            meshRenderer.material = onMaterial;
        else
            meshRenderer.material = offMaterial;
    }

    private void SetOffMaterial(BulletToggle bulletToggle)
    {
        meshRenderer.material = offMaterial;
    }
    private void SetOnMaterial(BulletToggle bulletToggle)
    {
        meshRenderer.material = onMaterial;
    }
}
