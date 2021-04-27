using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleAnimation : MonoBehaviour, AnimationBase
{

    public ScaleProfile ScaleProfile;

    Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
    }

    public void Animate(bool value)
    {
        var scaleFactor = value ? ScaleProfile.scaleTo : startScale;
        transform.DOScale(scaleFactor, ScaleProfile.speed).SetEase(ScaleProfile.interpolation);      
    }

}

