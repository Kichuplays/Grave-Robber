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
    public bool isAttacking;
    [SerializeField] protected float targetDistance; //the desiered distane between the target and self

    protected Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(target != null)
        {
            ChasePlayer();
            isAttacking = true;
        }
        else
        {
            Patrol();
        }
    }

    void ChasePlayer()
    {

    }

    void Patrol()
    {

    }
}
