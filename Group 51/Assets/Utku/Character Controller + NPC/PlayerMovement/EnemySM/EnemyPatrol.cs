using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;
    public float patrolSpeed;
    public float patrol_acceleration;
    private int moveDirection = 0;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Transform _currenttransform;
    private Vector2 velocity;
    float trans1;
    float trans2;
    [SerializeField] private float enemy_scale;

    private void Awake()
    {
        trans1 = point1.transform.position.x;
        trans2 = point2.transform.position.x;
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _currenttransform = GetComponent<Transform>();
    }




    public void Patrol()
    {
        float desiredspeed = -patrolSpeed;
        float maxAcceleration = patrol_acceleration * Time.deltaTime;
        switch (moveDirection)
        {
            case 0://left
                
                velocity.x = Mathf.MoveTowards(velocity.x, desiredspeed, maxAcceleration);
                velocity.y = _rigidbody.velocity.y;
                _rigidbody.velocity = velocity;
                if (transform.position.x < trans1) { moveDirection = 1; _currenttransform.localScale = new Vector3((enemy_scale), (enemy_scale), 1); };
                break;
            case 1://right
                desiredspeed = desiredspeed * (-1f);
                velocity.x = Mathf.MoveTowards(velocity.x, desiredspeed, maxAcceleration);
                velocity.y = _rigidbody.velocity.y;
                _rigidbody.velocity = velocity;
                if (transform.position.x > trans2) { moveDirection = 0; _currenttransform.localScale = new Vector3(-(enemy_scale), (enemy_scale), 1); };
                break;
        }
    }





    // Start is called before the first frame update
}
