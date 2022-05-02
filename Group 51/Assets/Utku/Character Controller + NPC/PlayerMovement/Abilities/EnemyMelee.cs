using UnityEngine;

namespace Shinjingi
{
    public class EnemyMelee : MonoBehaviour
    {


        private GroundCheck ground;
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
            ground = GetComponent<GroundCheck>();
            _animator = GetComponent<Animator>();

        }
        // Update is called once per frame
        void Update()
        {
            //desiredAttack |= controller.input.RetrieveAttackInput();
        }

        private void FixedUpdate()
        {
            onGround = ground.IsGrounded();


            if (desiredAttack && onGround)
            {
                desiredAttack = false;
                _animator.SetTrigger("Attack");
            }
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
}
