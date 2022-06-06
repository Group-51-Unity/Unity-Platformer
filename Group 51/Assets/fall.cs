using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour
{
    [SerializeField] private Transform TeleportPoint;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Transform>().position = TeleportPoint.position;
    }
}
