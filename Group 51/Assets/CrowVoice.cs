using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowVoice : MonoBehaviour
{
    [SerializeField] private AudioSource crowSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            crowSound.Play();
        }

    }
}
