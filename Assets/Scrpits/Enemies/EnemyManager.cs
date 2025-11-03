using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    Enemy[] enemies;

    void Start()
    {
        GameObject[] enemyObject = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = new Enemy[enemyObject.Length];
        for (int i = 0; i < enemyObject.Length; i++)
        {
            enemies[i] = enemyObject[i].GetComponent<Enemy>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
