using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RobotSound")]
public class RobotSounds : ScriptableObject
{
    public string room;
    public List<AudioClip> sounds;
}
