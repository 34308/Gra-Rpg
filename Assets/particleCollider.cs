using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleCollider : MonoBehaviour
{
    public bool _isIn=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isIn = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            _isIn = true;
        }
    }
}
