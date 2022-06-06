using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth=100f;
    public float currentHealth;
    private Animator _animator;
    public Rigidbody2D _rigidbody;
    private Vector2 velocity;
    private enemyFlash _enemyFlash;
    
    void Awake()
    {
        currentHealth = maxHealth;
        _animator = GetComponent<Animator>();
        Physics2D.IgnoreLayerCollision(6, 7);
        Physics2D.IgnoreLayerCollision(7, 7);
        Physics2D.IgnoreLayerCollision(6, 6);
        _rigidbody = GetComponent<Rigidbody2D>();
        _enemyFlash = GetComponent<enemyFlash>();
    }

    public void takeDamage(float Damage)
    {
        velocity.x = 0;
        velocity.y = 0; 
        currentHealth -= Damage;
        _rigidbody.velocity = velocity;
        Debug.Log("enemy took damage");
        _enemyFlash.Flash();
        if (gameObject.GetComponent<Animation>() != null)
        {
            gameObject.GetComponent<Animation>().Play("ghoulTakeDamage");
        }
        _animator.SetTrigger("getHit");
        if (currentHealth < 0)
        {
            Die();
        }

    }

    public void Die()
    {
        Debug.Log("Enemy Died");
        _animator.SetBool("Dead", true);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        this.enabled = false;
    }

    // Update is called once per frame
    
}
