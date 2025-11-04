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


    public void Start()
    {
        currentHealth = maxHealth;

    }
  

    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            gameManager.Winner();
        }
    }


}
