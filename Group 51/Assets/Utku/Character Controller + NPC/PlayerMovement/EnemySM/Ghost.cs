using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public GameObject deathPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Jump>().maxJump++;
            Instantiate(deathPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
