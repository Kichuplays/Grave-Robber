using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    // Gjort av Aiden
    //Referens till gamemanager
    public ButtonUI gameManager;
    //Spelarens Max health som är 100
    public int maxHealth = 100;
    // Spelarens nuvarande health
    public int currentHealth;
    // Hur mycket damage som spelaren tar
    public int Damage = 1;
    // Referens till healthbar scripten genom healthbar gameobject
    public HealthBar healthBar;
    [SerializeField] float knockBack = 200; //added by hannes
    //rigibody2d referens
    Rigidbody2D rb;

    public void Start()
    {
        // Fixars spelarens max health och healthbar, och får rigibody.
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = gameObject.GetComponent<Rigidbody2D>();
       
    }
  

    public void TakeDamage(int Damage, Transform attacker)
    {
       // När spelaren tar damage så blir spelaren puttad bak 
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
            // spelarens health är noll, så tar sönder spelaren och sätter på game over
            Destroy(gameObject);
            gameManager.Winner();
        }
        // Health bar fixar till hur mycket health spelaren har nu
        healthBar.SetHealth(currentHealth);
    }


}
