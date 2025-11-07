using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HealthBar : MonoBehaviour
{
    // gjord av Aiden
    // referenes till healthbar
    public Slider slider;

    public void SetMaxHealth(int health)
    {
        // Sätta healthbar max value till spelarns Max health
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        // Funktionen uppdaterar healthbar till spelarens health
        slider.value = health;
    }
}
