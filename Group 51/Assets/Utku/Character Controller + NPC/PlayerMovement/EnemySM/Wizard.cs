using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    [SerializeField]private Transform Player;
    private Rigidbody2D _rigidbody;
    [SerializeField] private float attackRangeEnemy = 2f;
    private Animator animator;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Player.position, _rigidbody.position) < attackRangeEnemy)
        {
            animator.SetTrigger("Attack");
        }
    }
}
