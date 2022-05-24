using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul : MonoBehaviour
{
    private EnemyPatrol _enemypatrol;
    // Start is called before the first frame update
    private BoxCollider2D _boxCollider;
    private EnemyHealth _enemyHealth;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private int ghoulDamage;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _enemypatrol = GetComponent<EnemyPatrol>();
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float health = _enemyHealth.currentHealth;
        if (health > 0f)
        {

            _enemypatrol.Patrol();
            checkPlayerHit();
        }
        gameObject.GetComponent<Animation>().Play("ghoulTakeDamage");
    }



    public void checkPlayerHit()
    {

        Collider2D hitPlayer = Physics2D.OverlapCircle(_boxCollider.bounds.center, _boxCollider.bounds.size.x , _mask);
        if (hitPlayer)
        {
            hitPlayer.GetComponent<PlayerHealth>().takeDamage(ghoulDamage);

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_boxCollider.bounds.center, _boxCollider.bounds.size.x);
      
    }

}
