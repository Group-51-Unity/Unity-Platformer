using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioJump : MonoBehaviour
{
    public AudioSource jumpSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void jumpSound()
    {
        jumpSoundEffect.Play();
    }
}
