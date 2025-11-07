using UnityEngine;

public class ArmFollow : MonoBehaviour //made by Atilla
{
    public Transform player;
    public Transform shovelTip; // Point of the shovel or hammer

    void Update()
    {
        if (player == null || shovelTip == null) return;

        // Calculate direction and distance
        Vector2 dir = shovelTip.position - player.position;
        float dist = dir.magnitude;

        // Position arm halfway between
        transform.position = player.position + (Vector3)dir * 0.5f;

        // Rotate to face the shovel
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Scale arm to stretch between player and shovel
        transform.localScale = new Vector3(dist, transform.localScale.y, transform.localScale.z);
    }
}
