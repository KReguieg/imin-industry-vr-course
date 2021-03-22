using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveAnimation : MonoBehaviour, AnimationBase
{

    public MoveProfile MoveProfile;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    public void Animate(bool value)
    {
        var position = value ? MoveProfile.moveTo : startPos;
        transform.DOMove(position, MoveProfile.speed);      
    }

}

