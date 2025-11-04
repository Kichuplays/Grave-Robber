using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    public Rigidbody2D rb;
    private float rotateSpeed = 5f;
    private float followStrength = 10f;
    private float damping = 100f; // How much drag/smoothness it has

    private Vector2 targetPos;

    private float shovelLength = 1.5f; // distance from handle to tip

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        FollowMouse();
        RotateTowardMouse();
    }

    private void FollowMouse()
    {
        Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos = mouseWorld;

        // Move so the tip (not center) stays on the mouse
        Vector2 dir = (targetPos - rb.position).normalized;
        Vector2 desiredPos = targetPos - dir * shovelLength;
        Vector2 moveDir = (desiredPos - rb.position);

        rb.AddForce(moveDir * followStrength * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }


    private void RotateTowardMouse()
    {
        Vector2 mouseDir = (targetPos - rb.position).normalized;
        float angle = Mathf.Atan2(mouseDir.y, mouseDir.x) * Mathf.Rad2Deg - 90f; // -90 aligns tip upward
        float newAngle = Mathf.LerpAngle(rb.rotation, angle, rotateSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(newAngle);
    }
}
