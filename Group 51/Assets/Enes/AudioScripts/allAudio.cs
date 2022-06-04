using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allAudio : MonoBehaviour
{
    public AudioSource attackSoundEffect;
    public AudioSource runSoundEffect;
    public AudioSource jumpSoundEffect;
    public AudioSource fallSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void RunningSound()
    {
        runSoundEffect.Play();
    }
    void jumpSound()
    {
        jumpSoundEffect.Play();
    }
    void AttackSound()
    {
        attackSoundEffect.Play();
    }
    void fallingSound()
    {
        fallSoundEffect.Play();
    }

}
