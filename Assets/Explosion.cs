using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<enemyHealthController>().takeDemage(5);
            CallAfterDelay.Create(0.3f, () => {
               Destroy(this);
            });
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
