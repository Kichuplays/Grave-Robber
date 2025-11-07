using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget; //Teleporter2
    public GameObject thePlayer; //Vår player
    private void OnTriggerEnter2D(Collider2D collision) //Om vi triggar en kollision, byt position till Teleporter 2
    {
        thePlayer.transform.position = teleportTarget.transform.position;
    }

}

