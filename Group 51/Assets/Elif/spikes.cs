using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{
    public HealthBar healthBar;

    public float maxHealth;
    public float currentHealth;
    private Animator _animator;

    void Awake()
    {
        maxHealth = 100f;
        currentHealth = maxHealth;
        _animator = GetComponent<Animator>();
        healthBar = FindObjectOfType<HealthBar>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            currentHealth -= 2;
            healthBar.UpdateHealth(currentHealth);

            if (currentHealth <= 0)
            {
                Die();
            }

        }
    }

    void Die()
    {
        _animator.SetBool("Dead", true);
        this.enabled = false;
    }
}
