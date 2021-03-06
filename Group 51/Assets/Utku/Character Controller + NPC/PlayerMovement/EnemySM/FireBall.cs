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
        _rigidbody.AddForce(new Vector2(9.8f * 25f, 9.8f * 25f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().takeDamage(bulletDamage);
        }
    }



}
