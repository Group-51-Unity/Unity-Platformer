using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(PlayerInputGet))]
[RequireComponent(typeof(GroundCheck))]
public class Move : MonoBehaviour
{

    public float maxSpeed;
    public float acceleration;
    public float airAcceleration;
    private float maxSpeedChange;
    private Vector2 desDirection;
    private Vector2 desSpeed;
    public Vector2 velocity;
    private Rigidbody2D _rigidbody;
    private Jump _jump;
    private Animator _animator;
    private PlayerInputGet _playerInputGet;
    private GroundCheck _groundCheck;
    private Transform _transform;
    public float mainCharScale;
    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInputGet = GetComponent<PlayerInputGet>();
        _groundCheck = GetComponent<GroundCheck>();
        _jump = GetComponent<Jump>();
        _animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        desDirection.x = _playerInputGet.GetMoveInput();
        desSpeed = new Vector2(maxSpeed * desDirection.x, 0f);
        _animator.SetFloat("Speed", Mathf.Abs(velocity.x));
        _animator.SetFloat("verticalSpeed", velocity.y);

    }

    private void FixedUpdate()
    {
        velocity = _rigidbody.velocity;
        if (desSpeed.x == 0 && velocity.x == 0 && velocity.y == 0) { return; }
        if (_groundCheck.IsGrounded())
        {
            maxSpeedChange = acceleration * Time.deltaTime;
            _jump.setJumpPhase(0);
            _animator.SetBool("onGround", true);
        }
        else
        {
            _jump.setJumpPhase(1);
            maxSpeedChange = airAcceleration * Time.deltaTime;
            _animator.SetBool("onGround", false);
        }
        velocity.x = Mathf.MoveTowards(velocity.x, desSpeed.x, maxSpeedChange);
        if (_rigidbody.velocity.x < 0f) { _transform.localScale = new Vector3(-(mainCharScale), (mainCharScale), 1); }
        else { _transform.localScale = new Vector3((mainCharScale), (mainCharScale), 1); }
        _rigidbody.velocity = velocity;
    }
}