using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityAnimation : MonoBehaviour
{
    [System.Serializable]
    public struct BoolParameter
    {
        public string name;
        public bool value;
    }

    [SerializeField]
    public List<BoolParameter> boolParameters;

    public Animator animator;


    public void Animate()
    {
        foreach(BoolParameter param in boolParameters)
        {
            animator.SetBool(param.name, param.value);
        }
    }

    public void AnimateReverse()
    {
        foreach (BoolParameter param in boolParameters)
        {
            animator.SetBool(param.name, !param.value);
        }
    }

    public void SetAllToValue(bool value)
    {
        foreach (BoolParameter param in boolParameters)
        {
            animator.SetBool(param.name, value);
        }
    }
}
