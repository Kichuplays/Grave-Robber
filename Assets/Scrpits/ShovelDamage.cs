using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelDamage : MonoBehaviour
{
    public int damage;
    [SerializeField] float knockBack = 200;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Applya damage när bulleten träffar en enemy med Health komponent
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.GetComponent<Enemy>())
            {
                Enemy target = collision.GetComponent<Enemy>();
                target.TakeDamage(damage, 0.5f, gameObject.GetComponent<Rigidbody2D>(), knockBack);
            }
        }
    }
}
