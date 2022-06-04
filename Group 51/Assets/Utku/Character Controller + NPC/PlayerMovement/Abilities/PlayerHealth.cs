using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    //aybars health bar
    public HealthBar healthBar;
    public float invulnerableSeconds;
    private float nextDamageTime = 0f;
    private playerFlash _playerFlash;
    
    
    // Start is called before the first frame update
    public float maxHealth;
    public float currentHealth;
    private Animator _animator;
    void Awake()
    {
        maxHealth = 100f;
        currentHealth = maxHealth;
        _animator = GetComponent<Animator>();
        healthBar = FindObjectOfType<HealthBar>();
        _playerFlash = GetComponent<playerFlash>();
    }




    public void takeDamage(float Damage)
    {
        if(Time.time <= nextDamageTime)
        {
            return;
        }
        nextDamageTime = Time.time + invulnerableSeconds;
        currentHealth -= Damage;
        healthBar.UpdateHealth(currentHealth);
        _playerFlash.Flash();
        Debug.Log("I took damage");
        _animator.SetTrigger("getHit");
        if (currentHealth < 0)
        {
            Die();
        }

    }

    void Die()
    {
        _animator.SetBool("Dead", true);
        //GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    // Update is called once per frame

}
