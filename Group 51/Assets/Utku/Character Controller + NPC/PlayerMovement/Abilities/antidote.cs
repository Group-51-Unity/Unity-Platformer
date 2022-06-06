using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antidote : MonoBehaviour
{
    // Start is called before the first frame update
    public float healingAmount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("antidote");
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().Heal(healingAmount);
            Destroy(gameObject);
        }
    }
}
