using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul : MonoBehaviour
{
    private EnemyPatrol _enemypatrol;
    // Start is called before the first frame update



    private void Awake()
    {
        _enemypatrol = GetComponent<EnemyPatrol>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        _enemypatrol.Patrol();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("ghoul has hit player");
        }
    }


}
