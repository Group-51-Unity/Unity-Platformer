using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        _animator.SetFloat("Speed", Mathf.Abs(_rigidbody.velocity.x));
    }
}
