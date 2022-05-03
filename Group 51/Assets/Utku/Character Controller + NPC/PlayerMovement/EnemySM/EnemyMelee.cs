using UnityEngine;


    public class EnemyMelee : MonoBehaviour
    {



        public Transform attackPoint;
        public float attackRange = 0.5f;
        public LayerMask playerLayers;

        private bool desiredAttack;
        private bool onGround;
        private Animator _animator;

        public int attackDamage;

        // Start is called before the first frame update
        void Awake()
        {
            _animator = GetComponent<Animator>();

        }
        // Update is called once per frame



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

