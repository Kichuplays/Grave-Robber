using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : Enemy
{
    private void Update()
    {
        if (target != null)
        {
            ChasePlayer();
            isAttacking = true;
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        rb.AddForce(Vector2.up * patrolSpeed);
    }

    void ChasePlayer()
    {
        if(target.position.x > transform.position.x)
        {
            rb.AddForce(Vector2.right * chaseSpeed);
        }
        
        if(target.position.x < transform.position.x)
        {
            rb.AddForce(Vector2.left * chaseSpeed);
        }

        print($"{gameObject.name} is chasing player");
    }
}
