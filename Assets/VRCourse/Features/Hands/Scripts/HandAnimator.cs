using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof (Animator))]
public class HandAnimator : MonoBehaviour
{
    [SerializeField] private float animationSpeed = 15.0f;
    [SerializeField] private InputActionReference controllerActionGrip;
    [SerializeField] private InputActionReference controllerActionTrigger;

    private Animator handAnimator = null;

    /// <summary>
    /// List of fingers animated when grabbing / using grab action
    /// </summary>
    private readonly List<Finger> grippingFingers = new List<Finger>()
    {
        new Finger(FingerType.Middle),
        new Finger(FingerType.Ring),
        new Finger(FingerType.Pinky)
    };

    /// <summary>
    /// List of fingers animated when pointing / using trigger action
    /// </summary>
    private readonly List<Finger> pointingFingers = new List<Finger>()
    {
        new Finger(FingerType.Index)
    };

    /// <summary>
    /// Add your own hand animation here. For example a fist or a peace sign.
    /// </summary>
    //private readonly List<Finger> Fingers = new List<Finger>()
    //{
    //    new Finger(FingerType.Index)
    //};

    private void OnEnable()
    {
        // Have it run your code when the Action is triggered.
        controllerActionGrip.action.performed += _ => PerformGripAnimation();
        controllerActionTrigger.action.performed += _ => PerformTriggerAnimation();

        controllerActionGrip.action.canceled += GripAction_canceled;
        controllerActionTrigger.action.canceled += TriggerAction_canceled;
    }

    private void TriggerAction_canceled(InputAction.CallbackContext obj)
    {
        SetFingerAnimationValues(pointingFingers, 0.0f);
        AnimateActionInput(pointingFingers);
    }

    private void GripAction_canceled(InputAction.CallbackContext obj)
    {
        SetFingerAnimationValues(grippingFingers, 0.0f);
        AnimateActionInput(grippingFingers);
    }

    private void PerformGripAnimation()
    {
        SetFingerAnimationValues(grippingFingers, 1.0f);
        AnimateActionInput(grippingFingers);
        //handAnimator.SetFloat("Index", 1.0f);
        //handAnimator.SetFloat("Thumb", 1.0f);
    }

    private void PerformTriggerAnimation()
    {
        SetFingerAnimationValues(pointingFingers, 1.0f);
        AnimateActionInput(pointingFingers);
    }


    private void Awake()
    {
        this.handAnimator = GetComponent<Animator>();
    }

    private void AnimateActionInput(List<Finger> fingersToAnimate)
    {
        foreach (Finger finger in fingersToAnimate)
        {
            AnimateFinger(finger.type.ToString(), finger.target); ;
        }
    }

    private void AnimateFinger(string fingerName, float animationBlendValue)
    {
        handAnimator.SetFloat(fingerName, animationBlendValue);
    }

    private void CheckForTriggerInput()
    {
        //if (controller.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.trigger, out float pointingValue))
        //    SetFingerAnimationValues(pointingFingers, pointingValue);
    }

    private void CheckForGripInput()
    {
        //if (controller.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.grip, out float gripValue))
        //    SetFingerAnimationValues(pointingFingers, gripValue);
    }

    private void SetFingerAnimationValues(List<Finger> fingersToAnimate, float targetValue)
    {
        foreach (Finger finger in fingersToAnimate)
        {
            finger.target = targetValue;
        }
    }

    private void SmoothFingerAnimation(List<Finger> fingersToSmooth)
    {
        foreach (Finger finger in fingersToSmooth)
        {
            float animationTimeStep = animationSpeed * Time.unscaledDeltaTime;
            finger.current = Mathf.MoveTowards(finger.current, finger.target, animationTimeStep);
        }
    }

    private void OnDisable()
    {
        controllerActionGrip.action.performed -= _ => PerformGripAnimation();
        controllerActionTrigger.action.performed -= _ => PerformTriggerAnimation();

        controllerActionGrip.action.canceled -= GripAction_canceled;
        controllerActionTrigger.action.canceled -= TriggerAction_canceled;
    }
}