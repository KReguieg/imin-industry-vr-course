using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRSimpleInteractable))]
public class OnHoverColorChanger : MonoBehaviour
{
    private XRSimpleInteractable simpleInteractable = null;
    private MeshRenderer meshRenderer = null;

    private Color startColor = Color.white;
    public Color hoverColor = new Color(0.019f, 0.733f, 0.827f);

    protected void OnEnable()
    {
        simpleInteractable = GetComponent<XRSimpleInteractable>();
        meshRenderer = GetComponent<MeshRenderer>();
        startColor = meshRenderer.material.color;

        simpleInteractable.hoverEntered.AddListener(OnHoverEntered);
        simpleInteractable.hoverExited.AddListener(OnHoverExited);
    }

    private void OnHoverExited(HoverExitEventArgs arg0)
    {
        meshRenderer.material.color = startColor;
    }

    private void OnHoverEntered(HoverEnterEventArgs arg0)
    {
        meshRenderer.material.color = hoverColor;
    }

    protected void OnDisable()
    {
        simpleInteractable.hoverEntered.RemoveListener(OnHoverEntered);
        simpleInteractable.hoverExited.RemoveListener(OnHoverExited);
    }

}