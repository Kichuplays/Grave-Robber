using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget; // för Teleporter2
    public GameObject thePlayer; // själva playern
    private void OnTriggerEnter2D(Collider2D collision) //Om vi triggar en kollision byter playern position till Teleporter 2
    {
        thePlayer.transform.position = teleportTarget.transform.position;
    }

}

