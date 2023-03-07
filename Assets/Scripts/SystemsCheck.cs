using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemsCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            {
                other.gameObject.GetComponent<LifeAndManaSystem>().takeDemage(2);
            }
        }
    }

}
