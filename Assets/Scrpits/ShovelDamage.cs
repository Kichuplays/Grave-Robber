using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelDamage : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Applya damage när bulleten träffar en enemy med Health komponent
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.GetComponent<Enemy>())
            {
                Enemy target = collision.GetComponent<Enemy>();
                target.TakeDamage(damage);
            }
        }
    }
}
