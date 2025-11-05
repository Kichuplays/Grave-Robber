using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillDamage : MonoBehaviour
{
    public int damagePerSecond = 2;       // Damage taken per second on the tilemap
    private bool isOnEnemy = false; //Är Player på tilen
    private float damageTimer = 0f;      //Timer för skada

    private Enemy enemytick; //Refererar till enemy skriptet

    void Start()
    {
        enemytick = GetComponent<Enemy>();
        if (enemytick == null)
        {
            Debug.LogError("PlayerMovement script not found on the player.");
        }
    }

    void Update()
    {
        // Apply damage over time while on the damage tile
        if (isOnEnemy)
        {
            damageTimer += Time.deltaTime;

            if (damageTimer >= 1f) // Apply damage every second
            {
                damageTimer = 0f; // Reset timer
                gameObject.GetComponent<Enemy>().TakeDamage(damagePerSecond);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Drill"))
        {
            isOnEnemy = true;
            Debug.Log("Player stepped on a dangerous tile!");

            // Slow down the player's movement
            if (enemytick != null)
            {
                //enemytick.SetSpeed(slowSpeed); //enemy slow when drill touchy
            }
        }
    }
}
