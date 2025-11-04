using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthbar;
    public float healthamount = 100f;


  
    public void Takedamage(float damage)
    {
        healthamount -= damage;
        healthbar.fillAmount = healthamount / 100f;

    }
    public void heal(float heal)
    {
        healthamount += heal;
        healthamount = Mathf.Clamp(healthamount, 0, 100);

        healthbar.fillAmount = healthamount / 100f;

    }
}
