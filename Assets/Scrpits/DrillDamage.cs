using System.Collections.Generic;
using UnityEngine;

public class DrillDamage : MonoBehaviour
{
    [Header("Base Settings")]
    public int baseDamage = 1;           // Starting damage per tick
    public float baseTickRate = 0.5f;    // Starting delay between damage ticks (seconds)

    [Header("Ramp Settings")]
    public int maxDamage = 10;           // Max damage cap
    public float minTickRate = 0.1f;     // Fastest possible tick speed
    public float rampSpeedDmg = 1f;      // How quickly the ramp increases per second
    public float rampSpeedTick = 2f;     // higher number = faster tickrate

    public KeyCode attachKey = KeyCode.E;
    public KeyCode detachKey = KeyCode.R;

    public Rigidbody2D playerRb;   // Drag in the player’s Rigidbody2D
    private Rigidbody2D attachedEnemy;

    private DistanceJoint2D joint;

    // Track each enemy individually
    private class DamageData
    {
        public float timer = 0f;
        public float stayTime = 0f;
    }

    private Dictionary<Enemy, DamageData> activeTargets = new Dictionary<Enemy, DamageData>();

    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();

        // Start attached to the player
        joint.connectedBody = playerRb;
        joint.distance = Vector2.Distance(transform.position, playerRb.position);
        joint.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            attachedEnemy = collision.collider.GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        // Attach to the enemy
        if (Input.GetKeyDown(attachKey) && attachedEnemy != null)
        {
            joint.connectedBody = attachedEnemy;
            joint.distance = Vector2.Distance(transform.position, attachedEnemy.position);
        }

        // Detach (return to player)
        if (Input.GetKeyDown(detachKey))
        {
            ReconnectToPlayer();
        }
    }

    // Called when enemy dies
    public void EnemyKilled(Rigidbody2D enemyRb)
    {
        if (attachedEnemy == enemyRb)
        {
            ReconnectToPlayer();
        }
    }

    private void ReconnectToPlayer()
    {
        attachedEnemy = null;
        joint.connectedBody = playerRb;
        joint.distance = Vector2.Distance(transform.position, playerRb.position);
        GetComponent<DistanceJoint2D>().distance = 2.5f;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy")) return;

        Enemy target = collision.gameObject.GetComponent<Enemy>();
        if (target == null) return;

        // Get or add enemy data
        if (!activeTargets.ContainsKey(target))
            activeTargets[target] = new DamageData();

        DamageData data = activeTargets[target];

        // Update stay time and cooldown
        data.stayTime += Time.deltaTime;
        data.timer -= Time.deltaTime;

        // Ramp up damage and tick rate
        float ramp = data.stayTime * rampSpeedDmg;
        float ramptick = data.stayTime * rampSpeedTick;
        int currentDamage = Mathf.Clamp(baseDamage + Mathf.FloorToInt(ramp), baseDamage, maxDamage);
        float currentTickRate = Mathf.Lerp(baseTickRate, minTickRate, Mathf.Clamp01(ramptick / (maxDamage - baseDamage)));

        // Apply tick damage if timer expired
        if (data.timer <= 0f)
        {
            target.TakeDamage(currentDamage, 0, gameObject.GetComponent<Rigidbody2D>(), 2);
            data.timer = currentTickRate; // Reset timer based on *ramped* tick rate
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy target = collision.gameObject.GetComponent<Enemy>();
            if (target != null && activeTargets.ContainsKey(target))
            {
                activeTargets.Remove(target);
            }
        }
    }
}
