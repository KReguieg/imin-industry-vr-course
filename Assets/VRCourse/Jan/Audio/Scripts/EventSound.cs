using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSound : MonoBehaviour
{
    public AudioClip audioclip_user;
    public AudioSource audiosource_user;
   

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void EventAudio()
    {
        audiosource_user.PlayOneShot(audioclip_user);
    }
}
