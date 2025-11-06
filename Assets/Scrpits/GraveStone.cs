using Cinemachine.Utility;
using System.Collections;
using UnityEngine;
using System;

public class GraveStone : MonoBehaviour
{
    [Header("Enemy Settings")]
    public GameObject enemyPrefab;   // The enemy to spawn
    public Transform spawnPoint;     // Optional spawn position (can be empty)

    public SpriteRenderer spriteRenderer;

    public WeaponSway swayShovel;
    public WeaponSway swayDrill;
    private void Start()
    {
        // Ensure collider acts as a trigger
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Only react to shovel
        if (collision.CompareTag("Shovel") || collision.CompareTag("Drill"))
        {
            swayShovel.followStrength = 1f;
            swayDrill.followStrength = 1f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Only react to shovel
        if (collision.CompareTag("Shovel") || collision.CompareTag("Drill"))
        {
            swayShovel.followStrength = 10f;
            swayDrill.followStrength = 10f;
            StartCoroutine(SpawnCoroutine());
            if (spriteRenderer != null)
                spriteRenderer.enabled = false;
        }
    }

    private IEnumerator SpawnCoroutine()
    {
        // Optional delay so you can play animation/sound first
        yield return new WaitForSeconds(0.5f);

        // Spawn enemy
        Vector3 spawnPos = (spawnPoint != null) ? spawnPoint.position : transform.position;
        if (enemyPrefab != null)
        {
            GameObject objectToSpawn = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            objectToSpawn.GetComponent<Enemy>().target = GameObject.Find("Player").transform;
        }
            
        else
            Debug.LogWarning("No enemyPrefab assigned!");

        // Now destroy the gravestone (after spawn)
        Destroy(gameObject);
    }
}

