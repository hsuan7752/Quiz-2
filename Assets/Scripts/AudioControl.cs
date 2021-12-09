using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    Animator anim;
    AudioSource src;
    void Start()
    {
        anim = GetComponent<Animator>();
        src = GetComponent<AudioSource>();

        src.pitch = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {        
        if (Player.moveSpeed != 0)
        {
            if (!src.isPlaying) src.Play();

            if (Player.moveSpeed > 2)
                src.pitch = 2.0f;
            else
                src.pitch = 1.5f;
        }
        else
        {
            if (src.isPlaying) GetComponent<AudioSource>().Stop();
        }
    }
}
