using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            PlayerDie();
        }

    }

    public void Heal(float HealAmount)
    {
        currentHealth += HealAmount;
        _playerFlash.FlashHeal();
        healthBar.UpdateHealth(currentHealth);
    }
    private void PlayerDie()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
