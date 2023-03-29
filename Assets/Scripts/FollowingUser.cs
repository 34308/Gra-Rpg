using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowingUser : MonoBehaviour
{
    public NavMeshAgent enemy;
    private bool _canShoot=true;
    Animator _animator;
    private float _howFar;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _howFar = Vector3.Distance(player.transform.position,transform.position);
        if(Random.Range(0, 1000) == 2 && _canShoot && _howFar>5&&_howFar<20)
        {
            _canShoot = false;
            _animator.SetBool("isThrowing",true);
        }
        else
        {
            enemy.SetDestination(player.position);
        }
       
    }
    public void EnemyDead()
    {
        enemy.isStopped = true;
    }

    //wywolywane w animcji
    public void Throw()
    {
        GetComponent<PathPrediction>().shoot();
    }
    public void EnableShoot()
    {
        _canShoot = true;
        _animator.SetBool("isThrowing",false);
    }
    
    public void DisableShoot()
    {
        _canShoot = false;
    }
}
