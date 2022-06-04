using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allAudio : MonoBehaviour
{
    public AudioSource runSoundEffect;
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
}
