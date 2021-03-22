using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum Direction {Forwards, Backwards}
public enum ColorMode {RandomColor, SelectedColor}


/// <summary>
/// Base Class for the AnimationProfiles which derives from scriptable object
/// </summary>
public abstract class AnimationProfileBase : ScriptableObject
{
    public List<AnimationProfileBase> profiles = new List<AnimationProfileBase>();

    public Ease interpolation;
    public float speed;

    public static int test;
}

[CreateAssetMenu(fileName = "ScaleProfile")]
public class ScaleProfile : AnimationProfileBase
{
    public Vector3 scaleTo;
}

[CreateAssetMenu(fileName = "MoveProfile")]
public class MoveProfile : AnimationProfileBase
{
    public Vector3 moveTo;
}

[CreateAssetMenu(fileName = "LightProfile")]
public class LightProfile : AnimationProfileBase
{
    public Color color;
    public ColorMode colorMode;
}

