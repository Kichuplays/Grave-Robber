using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 3;
    public int currentHealth;


    public void Start()
    {
        currentHealth = maxHealth;

    }
  

    void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
    }


}
