using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class Enemy : MonoBehaviour
{
    [Header("Speeds")]
    [SerializeField] public float chaseSpeed;

    [Header("Damage")]
    [SerializeField] int health = 10;
    [SerializeField] float knockBack;
    public int damage = 1;


    [Header("Targeting")]
    public Transform target;
    public bool isAttacking;
    [SerializeField] protected float targetDistance; //the desiered distane between the target and self
    public bool isFacingRight;

    protected Rigidbody2D rb;

    public int scoreValue;

    public Vector2 chargeDirection;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
  
    void Update()
    {
        float moveDirection = Input.GetAxis("Horizontal"); //if player kollar horizontellt
        {
            if (moveDirection > 0 && !isFacingRight)
            {
                Flip();
            }
            if (moveDirection < 0 && isFacingRight)
            {
                Flip();
            }
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();

            if (player != null)
            {
                player.TakeDamage(damage, transform);
            }
        }
    }

    public void TakeDamage(int damage, float minDamageVel, Rigidbody2D arb)
    {
        if(arb.velocity.magnitude > minDamageVel)
        {
            health -= damage;
            rb.AddForce((arb.transform.position - target.position).normalized * knockBack);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            ScoreManager.Instance.AddScore(scoreValue);
        }
    }

}
