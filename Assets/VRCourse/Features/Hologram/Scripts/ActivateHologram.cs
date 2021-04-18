using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateHologram : MonoBehaviour
{
    XRGrabInteractable m_InteractableBase;
    public GameObject hologram;

    private float trigerPressWaitTime = 0.1f;
    private float trigerPressTime;

    private bool pressedTriger;


    void Start()
    {
        hologram.SetActive(false);
        m_InteractableBase = GetComponent<XRGrabInteractable>();
        m_InteractableBase.selectExited.AddListener(HologramDropped);
        m_InteractableBase.activated.AddListener(TriggerPulled);
        m_InteractableBase.deactivated.AddListener(TriggerReleased);

    }

    void Update()
    {
        if( pressedTriger)
        {
            trigerPressTime += Time.deltaTime;

            if( trigerPressTime >= trigerPressWaitTime)
            {
                if(!hologram.activeInHierarchy)
                {
                    hologram.SetActive(true);
                }
            }
        }
    }

    private void TriggerReleased(DeactivateEventArgs arg0)
    {
        pressedTriger = false;
        trigerPressTime = 0f;
        hologram.SetActive(false);
    }

    private void TriggerPulled(ActivateEventArgs arg0)
    {
        pressedTriger = true;
    }

    private void HologramDropped(SelectExitEventArgs arg0)
    {
        pressedTriger = false;
        trigerPressTime = 0f;
        hologram.SetActive(false);
    }

   
}

    
