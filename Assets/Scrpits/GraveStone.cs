using UnityEngine;

public class EnemyTouchy : MonoBehaviour
{
    public int damage = 2; //Skada som spelaren ska ta när Enemy rör honom

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shovel"))
        {
            //Shovel Graveston = collision.gameObject.GetComponent<Shovel>();

            //if (Graveston != null)
            {
             //   player.TakeDamage(damage);
            }
        }
    }
}
