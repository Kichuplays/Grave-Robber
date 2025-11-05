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
    // Track each enemy individually
    private class DamageData
    {
        public float timer = 0f;
        public float stayTime = 0f;
    }

    private Dictionary<Enemy, DamageData> activeTargets = new Dictionary<Enemy, DamageData>();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) return;

        Enemy target = collision.GetComponent<Enemy>();
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy target = collision.GetComponent<Enemy>();
            if (target != null && activeTargets.ContainsKey(target))
            {
                activeTargets.Remove(target);
            }
        }
    }
}
