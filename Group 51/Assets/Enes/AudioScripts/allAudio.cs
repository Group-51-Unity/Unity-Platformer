using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allAudio : MonoBehaviour
{
    public AudioSource attackSoundEffect;
    public AudioSource runSoundEffect;
    public AudioSource jumpSoundEffect;
    public AudioSource fallSoundEffect;
    public Animator _animator;
    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void RunningSound()
    {
        if (_animator.GetFloat("Speed") >0.1)
        {
            runSoundEffect.Play();
        }
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
