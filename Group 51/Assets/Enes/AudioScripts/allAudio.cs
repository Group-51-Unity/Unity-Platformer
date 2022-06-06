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
    [SerializeField] public AudioSource healthAdditionSound;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("potion"))
        {
            healthAdditionSound.Play();
        }

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
