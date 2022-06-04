using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(PlayerInputGet))]
[RequireComponent(typeof(GroundCheck))]
public class Jump : MonoBehaviour
{
    private bool jumpRequest;
    public float maxJump;
    public float jumpSpeed;
    public int jumpPhase;
    private Vector2 velocity;
    private Rigidbody2D _rigidbody;

    private PlayerInputGet _playerInputGet;

    private Animator _animator;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInputGet = GetComponent<PlayerInputGet>();
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        jumpRequest |= _playerInputGet.GetJumpInput();
    }

    private void FixedUpdate()
    {
        velocity = _rigidbody.velocity;
        if (jumpRequest)
        {
            jumpRequest = false;
            JumpAction();
        }
        _rigidbody.velocity = velocity;

    }
    public void setJumpPhase(int i)
    {
        switch (i)
        {
            case 0:
                jumpPhase = 0;
                break;
            case 1:
                jumpPhase = Mathf.Max(1, jumpPhase);
                break;
        }


    }

    private void JumpAction()
    {
        _animator.SetTrigger("Jump");
        if (jumpPhase < maxJump)
        {
            jumpPhase++;
            velocity.y = jumpSpeed;
        }
    }
}