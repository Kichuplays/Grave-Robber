using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{

    public float multiplier; //Anton K, gör så att objektet rör sig långsammare eller snabbare än kameran.
    public new GameObject camera; 
    public Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate() //Anton K, Kameraföljning
    {
        transform.position = new Vector3(startPosition.x + (multiplier * camera.transform.position.x), transform.position.y, transform.position.z);
       
    }
}
