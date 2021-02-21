using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRSimpleInteractable))]
public class TouchSelect : MonoBehaviour
{
    XRSimpleInteractable m_SimpleInteractable;
    MeshRenderer m_MeshRenderer;

    static Color s_UnityMagenta = new Color(0.929f, 0.094f, 0.278f);
    public Color s_UnityCyan = new Color(0.019f, 0.733f, 0.827f);

    bool m_Held;

    protected void OnEnable()
    {
        m_SimpleInteractable = GetComponent<XRSimpleInteractable>();
        m_MeshRenderer = GetComponent<MeshRenderer>();

        m_SimpleInteractable.hoverEntered.AddListener(OnHoverEntered);
    }

    private void OnHoverEntered(HoverEnterEventArgs arg0)
    {
        Debug.Log(arg0.interactor.name);
        m_MeshRenderer.material.color = s_UnityCyan;
    }

    protected void OnDisable()
    {
        m_SimpleInteractable.firstHoverEntered.RemoveListener(OnHoverEntered);
    }

    protected virtual void OnSelectEntered(SelectEnterEventArgs args)
    {
        m_MeshRenderer.material.color = s_UnityCyan;
        m_Held = true;
    }

    protected virtual void OnSelectExited(SelectExitEventArgs args)
    {
        m_MeshRenderer.material.color = Color.white;
        m_Held = false;
    }

    protected virtual void OnLastHoverExited(HoverExitEventArgs args)
    {
        if (!m_Held)
        {
            m_MeshRenderer.material.color = Color.white;
        }
    }

    protected virtual void OnFirstHoverEntered(HoverEnterEventArgs args)
    {
        if (!m_Held)
        {
            m_MeshRenderer.material.color = s_UnityMagenta;
        }
    }
}