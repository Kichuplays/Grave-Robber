using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class BasicZombie : Enemy
{
    [Header("Specific to zombies")]
    [SerializeField] float climbForce, climbCheckRadius;
    [SerializeField] Transform climbCheck;
    [SerializeField] LayerMask groundLayer;
    bool needToClimb;
    private void Update()
    {
        needToClimb = Physics2D.OverlapCircle(climbCheck.position, climbCheckRadius, groundLayer);
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
                isFacingRight = true;
                transform.localScale = new Vector3(-1, 1, 1);
                print("the player is right");
            }

            if (target.position.x < transform.position.x)
            {
                rb.AddForce(Vector2.left * chaseSpeed);
                isFacingRight = false;
                transform.localScale = new Vector3(1, 1, 1);
                print("the player is left");
            }

            if (needToClimb)
            {
                rb.AddForce(Vector2.up * climbForce);
            }
        }
    }
}
