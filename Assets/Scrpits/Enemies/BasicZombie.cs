using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class BasicZombie : Enemy //script uses Enemy script as base, go look at that for more info
{
    [Header("Specific to zombies")]
    [SerializeField] float climbForce, climbCheckRadius;
    [SerializeField] Transform climbCheck;
    [SerializeField] LayerMask groundLayer;
    bool needToClimb;
    private void Update()
    {
        needToClimb = Physics2D.OverlapCircle(climbCheck.position, climbCheckRadius, groundLayer); //checks if the zombie needs to climb
        if (target != null) //if the zombie has a target
        {
            ChasePlayer(); //chase the target
            isAttacking = true; //let scripts know we are atacking
        }
        else //if there is no target
        {
            Idle(); //do jack shit
        }
    }

    void Idle()
    {
        //jack shit
    }

    void ChasePlayer()
    {
        if(Vector2.Distance(transform.position,target.position) > targetDistance) //if the distance between the zombie and target is more than the wants it to be
        {
            if (target.position.x > transform.position.x) //if the player is to the left
            {
                rb.AddForce(Vector2.right * chaseSpeed); //go right
                isFacingRight = true; //let things know the zombie is facing right
                transform.localScale = new Vector3(-1, 1, 1); //flip the zombie to the right
            }

            if (target.position.x < transform.position.x) //if the player is to the right
            {
                rb.AddForce(Vector2.left * chaseSpeed); //go left
                isFacingRight = false; //let things know the zombie is facing left
                transform.localScale = new Vector3(1, 1, 1); //flip the zombie to the left
            }

            if (needToClimb) //if the zombie needs to climb
            {
                rb.AddForce(Vector2.up * climbForce); //climb
            }
        }
    }
}
