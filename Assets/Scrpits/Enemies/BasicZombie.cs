using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class BasicZombie : Enemy
{
    [SerializeField] float climbForce;
    bool needToClimb;
    private void Update()
    {
        if (target != null)
        {
            ChasePlayer();
            isAttacking = true;
        }
        else
        {
            Idle();
        }
    }

    void Idle()
    {
        
    }

    void ChasePlayer()
    {
        if(Vector2.Distance(transform.position,target.position) > targetDistance)
        {
            print($"{gameObject.name} is chasing player");
            if (target.position.x > transform.position.x)
            {
                rb.AddForce(Vector2.right * chaseSpeed);
            }

            if (target.position.x < transform.position.x)
            {
                rb.AddForce(Vector2.left * chaseSpeed);
            }

            if (needToClimb)
            {
                rb.AddForce(Vector2.up * climbForce);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.position.y + collision.transform.localScale.y / 2 > transform.position.y && collision.gameObject.layer == 3) //if we are not standing on the objects roof
        {
            needToClimb = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        needToClimb = false;
    }
}
