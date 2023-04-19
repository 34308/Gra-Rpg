using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveStage : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    private bool _activated = false;
    private Vector3[] _enemyPositions=new Vector3 [3];


    private void Start()
    {
        _enemyPositions.SetValue(transform.GetChild(0).transform.position,0);
        _enemyPositions.SetValue(transform.GetChild(1).transform.position,1);
        _enemyPositions.SetValue(transform.GetChild(2).transform.position,2);

    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (!_activated)
        {
            if (other.CompareTag("Player"))
            {
             _activated = true;
                SpawnEnemys();
               
            }
        }
        
    }

    private void SpawnEnemys()
    {
        GameObject[] enemies = { enemy1, enemy2, enemy3 };
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                Instantiate(enemies[i], _enemyPositions[i], Quaternion.identity);
            }
        }

    }
}
