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
                SpawnEnemys();
                _activated = true;
            }
        }
        
    }

    private void SpawnEnemys()
    {
        Instantiate(enemy1, _enemyPositions[0], Quaternion.identity);
        Instantiate(enemy2, _enemyPositions[1], Quaternion.identity);
        Instantiate(enemy3, _enemyPositions[2], Quaternion.identity);
    }
}
