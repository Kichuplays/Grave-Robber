using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour //made by Atilla
{
    public GameObject thePlayer; // själva playern
    private void OnTriggerEnter2D(Collider2D other) //Om vi triggar en kollision byter playern position till Teleporter 2
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Ending");
        }
    }

}

