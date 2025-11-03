using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : Enemy
{
    private void Update()
    {
        if (target != null)
        {
            if (!tooManyAttackers)
            {
                //ChasePlayer();
                isAttacking = true;
            }
            else if (isAttacking)
            {
                ChasePlayer();
            }
            else
            {
                //HoverAraoundPlayer();
            }
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
        rb.AddForce(Vector2.up * chaseSpeed);

        print($"{gameObject.name} chasing player");
    }
}
