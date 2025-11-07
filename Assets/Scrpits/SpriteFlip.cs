using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpriteFlip : MonoBehaviour //made by Atilla
{
    public bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveDirection = Input.GetAxis("Horizontal"); //if player kollar horizontellt
        {
            if (moveDirection > 0 && !isFacingRight)
            {
                Flip();
            }
            if (moveDirection < 0 && isFacingRight)
            {
                Flip();
            }
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
