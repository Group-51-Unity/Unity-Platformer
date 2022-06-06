using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float fireSpeed = 2f;
    public Rigidbody2D _rigidbody;
    public float bulletDamage = 3f;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        _rigidbody.velocity = transform.up * fireSpeed * (-1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            collision.GetComponent<PlayerHealth>().takeDamage(bulletDamage);
        }
        Destroy(gameObject);
    }


}
