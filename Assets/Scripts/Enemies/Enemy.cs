using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class Enemy : MonoBehaviour
{
    [Header("Speeds")]
    [SerializeField] protected float chaseSpeed;
    [SerializeField] protected float patrolSpeed;

    [Header("Targeting")]
    public Transform target; //the thing they are going to attack
    public bool tooManyAttackers; // false means it's ok to attack
    public bool isAttacking;

    protected Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(target != null)
        {
            if (!tooManyAttackers)
            {
                ChasePlayer();
                isAttacking = true;
            }
            else if (isAttacking)
            {
                ChasePlayer();
            }
            else
            {
                HoverAraoundPlayer();
            }
        }
        else
        {
            Patrol();
        }
    }

    void ChasePlayer()
    {

    }

    void HoverAraoundPlayer()
    {

    }

    void Patrol()
    {

    }
}
