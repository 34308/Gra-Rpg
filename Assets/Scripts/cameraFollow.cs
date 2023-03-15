using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject player;
    public float cameraHeight = 210.0f;
    public float camerax = 0;
    public float cameraz =-15;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = player.transform.position;
        pos.y += cameraHeight;
        pos.z += cameraz;
        pos.x += camerax;
        transform.position = pos;
    }
}
