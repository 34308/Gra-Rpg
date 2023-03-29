using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ThrowableMovement: MonoBehaviour
{
    Vector3 startPosition;
    Vector3 endPosition;
    float currentLerpTime;
    private Transform player;
    private bool _isMoving = false;
    FollowingUser slime;
    private String _ownerName;
    private Vector3 lastPositon;
    private float Ctime=0.5f; //im mniejszy tym szybszy pocisk
    // Start is called before the first frame update
    void Start()
    {
        player =GameObject.FindGameObjectWithTag("Player").transform;
            slime = GetComponent<FollowingUser>();
        startPosition = transform.position;
        endPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isMoving)
        {
            currentLerpTime += Time.deltaTime;
            transform.LookAt(endPosition);
            lastPositon = transform.position;
            transform.position = Vector3.Lerp(startPosition, endPosition, currentLerpTime/Ctime);
            
        }
        if (transform.position == lastPositon)
        {
            Destroy(this.gameObject);
            if (_ownerName.Contains("slime"))
            {
                GameObject.Find(_ownerName).GetComponent<FollowingUser>().EnableShoot();
            }
            
        }
        
    }

    public void StartThrow()
    {
        _isMoving = true;
    }
    public void SetOwnerName(String name)
    {
        _ownerName = name;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Ground")
        {
            if (_ownerName.Contains("slime"))
            {
                GameObject.Find(_ownerName).GetComponent<FollowingUser>().EnableShoot();
            }
            player.GetComponent<LifeAndManaSystem>().takeDemage(2);
            Destroy(this.gameObject);
            
        }
        
    }
}
