using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRBaseInteractable))]
public class OnHoverColorChanger : MonoBehaviour
{
    private XRBaseInteractable simpleInteractable = null;
    private SkinnedMeshRenderer[] meshRenderer = null;

    private Color[] startColors = null;
    public Color hoverColor = new Color(0.019f, 0.733f, 0.827f);

    protected void OnEnable()
    {
        simpleInteractable = GetComponent<XRBaseInteractable>();
        meshRenderer = GetComponentsInChildren<SkinnedMeshRenderer>();

        startColors = new Color[meshRenderer.Length];

        for (int i = 0; i < meshRenderer.Length; i++)
        {
            startColors[i] = (meshRenderer[i].material.color != null) ? meshRenderer[i].material.color : Color.white;
        }

        simpleInteractable.hoverEntered.AddListener(OnHoverEntered);
        simpleInteractable.hoverExited.AddListener(OnHoverExited);
    }

    private void OnHoverExited(HoverExitEventArgs arg0)
    {
        for (int i = 0; i < meshRenderer.Length; i++)
        {
            meshRenderer[i].material.color = startColors[i];
        }
    }

    private void OnHoverEntered(HoverEnterEventArgs arg0)
    {
        for (int i = 0; i < meshRenderer.Length; i++)
        {
            meshRenderer[i].material.color = hoverColor;
        }
    }

    protected void OnDisable()
    {
        simpleInteractable.hoverEntered.RemoveListener(OnHoverEntered);
        simpleInteractable.hoverExited.RemoveListener(OnHoverExited);
    }

}