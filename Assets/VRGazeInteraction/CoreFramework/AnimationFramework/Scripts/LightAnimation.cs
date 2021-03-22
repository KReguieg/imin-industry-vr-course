using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class LightAnimation : MonoBehaviour, AnimationBase
{

    public LightProfile lightProfile;
    public Light light;

    public void Animate(bool value)
    {
        if (value)       
            light.DOIntensity(1, lightProfile.speed);
        
        else      
            light.DOIntensity(0, lightProfile.speed);
        
    }

}
