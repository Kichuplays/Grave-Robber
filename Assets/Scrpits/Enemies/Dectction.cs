using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]

public class Dectction : MonoBehaviour
{
    [SerializeField] Enemy[] enemiesThatActivate;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            print("PlayerTetected");
            foreach (Enemy enemy in enemiesThatActivate)
            {
                enemy.target = collision.transform;
            }
        }
    }
}
