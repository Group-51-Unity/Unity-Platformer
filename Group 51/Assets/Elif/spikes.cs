using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().takeDamage(2);
            collision.GetComponent<Rigidbody2D>().velocity = 4*Vector3.up;
        }
    }


}
