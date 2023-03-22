using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPrediction : MonoBehaviour
{
    LineRenderer line;
    Rigidbody bullet;
    public GameObject spike;
    Vector3 startPosition;
    Vector3 endPosition;
    float initialForce=30;
    Quaternion rotation;
    int indexOfLineRenderer = 0;
    int numberOfPointInLine = 2;
    int lastPoint=1;
    float timer = 0.1f;
    bool stopped = false;
    float finalAngle;

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

        CallAfterDelay.Create(0.5f, () => {
            GameObject goSpike=Instantiate(spike, transform.position, Quaternion.identity);
            goSpike.GetComponent<SpkieMovement>().SetOwnerName(transform.name);
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


    

