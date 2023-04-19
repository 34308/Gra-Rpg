using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSnakeHeadColider : MonoBehaviour
{
    public bool _isIn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            _isIn = true;
            Debug.Log(_isIn);
        }
    
    }

    private void OnTriggerExit(Collider other)
    {
       
        _isIn =false;
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
