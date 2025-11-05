using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public ButtonUI gameManager;

    public int maxHealth = 3;
    public int currentHealth;
    public int Damage = 1;

    [SerializeField] float knockBack = 200; //added by hannes
    Rigidbody2D rb;

    public void Start()
    {
        currentHealth = maxHealth;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
  

    public void TakeDamage(int Damage, Transform attacker)
    {
        currentHealth -= Damage;
        if(attacker.position.y - attacker.localScale.y/2 < transform.position.y + transform.localScale.y/2 - 0.25 && attacker.position.y + attacker.localScale.y / 2 > transform.position.y - transform.localScale.y / 2 + 0.25)
        {
            rb.position += new Vector2(0, 0.1f);
            rb.AddForce((transform.position - attacker.position).normalized * knockBack * 10);
            print("Applied from if");
        }
        else
        {
            rb.AddForce((transform.position - attacker.position).normalized * knockBack);
            print("Applied from else");
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            gameManager.Winner();
        }
    }


}
