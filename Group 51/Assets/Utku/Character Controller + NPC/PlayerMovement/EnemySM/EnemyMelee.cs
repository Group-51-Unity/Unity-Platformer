using UnityEngine;


public class EnemyMelee : MonoBehaviour
{



    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;
    private Vector2 velocity;

    private Rigidbody2D _rigidbody;

    public int attackDamage = 10;

        // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

    }
        // Update is called once per frame

    public void StartAttack()
    {
        velocity.x = 0;
        velocity.y = 0;
        _rigidbody.velocity = velocity;
    }

    public void AttackAction()
    {
        Collider2D hitPlayer = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayers);
        hitPlayer.GetComponent<PlayerHealth>().takeDamage(attackDamage);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}

