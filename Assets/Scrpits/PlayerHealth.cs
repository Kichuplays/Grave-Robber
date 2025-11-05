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
    public HealthBar healthBar;
    [SerializeField] float knockBack = 200; //added by hannes
    Rigidbody2D rb;

    public void Start()
    {
        currentHealth = maxHealth;
        rb = gameObject.GetComponent<Rigidbody2D>();
        healthBar.SetMaxHealth(maxHealth);
    }
  

    public void TakeDamage(int Damage, Transform attacker)
    {
        healthBar.SetHealth(currentHealth);
        currentHealth -= Damage;
        rb.AddForce((transform.position - attacker.position).normalized * knockBack);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            gameManager.Winner();
        }
    }


}
