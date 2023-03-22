using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpkieMovement : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 endPosition;
    float currentLerpTime;
    FollowingUser slime;
    private String _ownerName;
    private Vector3 lastPositon;
    private float Ctime=0.5f; //im mniejszy tym szybszy pocisk
    // Start is called before the first frame update
    void Start()
    {
        slime = GetComponent<FollowingUser>();
        startPosition = transform.position;
        endPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentLerpTime += Time.deltaTime;
        transform.LookAt(endPosition);
        lastPositon = transform.position;
        transform.position = Vector3.Lerp(startPosition, endPosition, currentLerpTime/Ctime);
        if (transform.position == lastPositon)
        {
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<FollowingUser>().EnableShoot();
            Destroy(this.gameObject);
            
        }
    }

    public void SetOwnerName(String name)
    {
        _ownerName = name;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Ground")
        {
            GameObject.Find(_ownerName).GetComponent<FollowingUser>().EnableShoot();
            
            Destroy(this.gameObject);
        }
        
    }
}
