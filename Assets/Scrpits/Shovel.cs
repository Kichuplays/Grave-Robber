using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;

    private GameObject player;

    Vector2 moveDir;
    private void LookAtMouse()
    {
        Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = mousePos - new Vector2(transform.position.x, transform.position.y); // Aims at mouse
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LookAtMouse(); // Aims at mouse
        //moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //rb.MovePosition(rb.position + moveDir * speed * Time.fixedDeltaTime);
    }
}

