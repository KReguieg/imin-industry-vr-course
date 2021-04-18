using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRBaseInteractable))]
public class OnHoverColorChanger : MonoBehaviour
{
    [SerializeField] private bool changeColorOnChildren = false;
    private XRBaseInteractable simpleInteractable = null;
    private List<Renderer> renderer = null;

    private Color[] startColors = null;
    public Color hoverColor = new Color(0.019f, 0.733f, 0.827f);

    protected void OnEnable()
    {
        simpleInteractable = GetComponent<XRBaseInteractable>();

        renderer = (changeColorOnChildren)? GetComponentsInChildren<Renderer>().ToList() : new List<Renderer>() { GetComponent<Renderer>() };

        startColors = new Color[renderer.Count];

        for (int i = 0; i < renderer.Count; i++)
        {
            startColors[i] = (renderer[i].material.color != null) ? renderer[i].material.color : Color.white;
        }

        simpleInteractable.hoverEntered.AddListener(OnHoverEntered);
        simpleInteractable.hoverExited.AddListener(OnHoverExited);
    }

    private void OnHoverExited(HoverExitEventArgs arg0)
    {
        for (int i = 0; i < renderer.Count; i++)
        {
            renderer[i].material.color = startColors[i];
        }
    }

    private void OnHoverEntered(HoverEnterEventArgs arg0)
    {
        for (int i = 0; i < renderer.Count; i++)
        {
            renderer[i].material.color = hoverColor;
        }
    }

    protected void OnDisable()
    {
        simpleInteractable.hoverEntered.RemoveListener(OnHoverEntered);
        simpleInteractable.hoverExited.RemoveListener(OnHoverExited);
    }

}