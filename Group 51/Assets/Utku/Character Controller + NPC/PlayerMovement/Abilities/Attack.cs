using UnityEngine;


    public class Attack: MonoBehaviour
    {
        private PlayerInputGet _playerinputget;
        private GroundCheck _groundcheck;
        public Transform attackPoint;
        public float attackRange = 0.5f;
        public LayerMask enemyLayers;
  

        private bool desiredAttack;
        private bool onGround;
        private Animator _animator;

        public int attackDamage;
   

        // Start is called before the first frame update
        void Awake()
        {
            _groundcheck = GetComponent<GroundCheck>();
            _playerinputget = GetComponent<PlayerInputGet>();
            _animator = GetComponent<Animator>();

        }
        // Update is called once per frame
        void Update()
        {
    
            desiredAttack |= _playerinputget.GetAttackInput();
        }

        private void FixedUpdate()
        {
           


            if (desiredAttack)
            {
                onGround = _groundcheck.IsGrounded();
                if (onGround)
                {
                    desiredAttack = false;
                    //_animator.SetTrigger("Attack");
                    characterAttack();
                }
                
            }
        }
        public void characterAttack()
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyHealth>().takeDamage(attackDamage);
            }

        }

        private void OnDrawGizmosSelected()
        {
            if (attackPoint != null)
            {
                Gizmos.DrawWireSphere(attackPoint.position, attackRange);
            }
        }
    }

