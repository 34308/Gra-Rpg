using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class checkpoint1 : MonoBehaviour
{
    [SerializeField] private Transform _light;
  
    
    // Start is called before the first frame update
    void Start()
    {
        _light.rotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        _light.rotation = Quaternion.Euler(50, 11, 0);
    }
}
