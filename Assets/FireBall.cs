using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class FireBall : MonoBehaviour
{
    public float speed;
    public int damage;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        rb.gravityScale = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth pp = collision.gameObject.GetComponent<PlayerHealth>();
        if(pp != null)
        {
            pp.TakeDamage(damage, transform);
        }
        Destroy(gameObject);
    }
}
