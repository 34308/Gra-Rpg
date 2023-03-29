using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PathPrediction : MonoBehaviour
{
    LineRenderer line;
    [FormerlySerializedAs("spike")] public GameObject throwable;
    Vector3 startPosition;
    Vector3 endPosition;
    Quaternion rotation;
    int indexOfLineRenderer = 0;
    int numberOfPointInLine = 2;
    int lastPoint=1;
    float finalAngle;
    private Transform _spawnPosition;

    private bool _drawLine;

    // Start is called before the first frame update
    void Start()
    {
        endPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        startPosition = transform.position;
        line = GetComponent<LineRenderer>();
        line.positionCount=(numberOfPointInLine);        
        lastPoint = numberOfPointInLine - 1;
    }

    public void SpawnPosition(Transform spawnTransformOfObject)
    {
        _spawnPosition = spawnTransformOfObject;
    }
    private void Update()
    {
        startPosition = transform.position;
        if (_drawLine)
        {
            drwaLine();
        }
        
        
    }

    // Update is called once per frame

    public void shoot()
    {
        startPosition = transform.position;
        startPosition.y = 2;
        endPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        _drawLine = true;

        CallAfterDelay.Create(0.1f, () => {
            if (_spawnPosition==null)
            {
                _spawnPosition = transform;
            }
            GameObject goSpike=Instantiate(throwable, _spawnPosition.position, Quaternion.identity);
            
            goSpike.GetComponent<ThrowableMovement>().SetOwnerName(transform.name);
            goSpike.GetComponent<ThrowableMovement>().StartThrow();
            cleanLine();
        });
        
    }

    private void cleanLine()
    {
        line.enabled = false;
        _drawLine = false;
    }

    private void drwaLine()
    {
        line.enabled = true;
        line.SetPosition(indexOfLineRenderer, startPosition);
        line.SetPosition(lastPoint, endPosition);

    }
}


    

