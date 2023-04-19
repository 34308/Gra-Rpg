using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class StoneSnakeMoving : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private NavMeshAgent agent;
    
    int stopping_distance = 20;
    private Transform player;
    private BoxCollider _attackCollider;
    Animator animator;
    private Transform _head;
    CapsuleCollider partcicleColider;
    
    // Start is called before the first frame update
    void Start()
    {
        
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        
        partcicleColider= _particleSystem.GetComponent<CapsuleCollider>();
        _head = transform.GetChild(0).GetChild(7).GetChild(0).GetChild(1).GetChild(0).GetChild(0);
        _attackCollider = GetComponent<BoxCollider>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = stopping_distance;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void AtackBeamRay()
    {
        agent.isStopped =true;
        _particleSystem.Play();
        partcicleColider.radius = (float)4.738994;
        partcicleColider.height = (float)27.37351;
    }


    public void HeadButt()
    {
        if (GetComponentInChildren<StoneSnakeHeadColider>()._isIn)
        {
            player.GetComponent<LifeAndManaSystem>().takeDemage(4);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            BoxCollider boxCollider = GetComponent<BoxCollider>();
           
            if (_particleSystem.isPlaying && GetComponentInChildren<particleCollider>()._isIn)
            {
                player.GetComponent<LifeAndManaSystem>().takeDemage(2);
            }
            animator.SetInteger("attack",Random.Range(1, 3));
        }
    }

    public void AfterAttack()
    {
        agent.isStopped = false;

        _particleSystem.Stop();
        partcicleColider.radius = (float)0;
        partcicleColider.height = (float)0;
        animator.SetInteger("attack",0);
        animator.SetBool("IsMoving", true);
        animator.SetBool("IsRunning", true);
    }

    public void EnemyDead()
    {
        agent.isStopped = true;
        CallAfterDelay.Create(3.5f, () =>
        {
            Destroy(this.gameObject);
        });
    }
    // Update is called once per frame
    void Update()
    {
        
        //transform.position= new Vector3(transform.position.x,0,transform.position.z);
        _particleSystem.transform.position=_head.position;
        var distance=Vector3.Distance(_head.position, player.position);
        if (distance < stopping_distance)
        {
            agent.stoppingDistance = distance-0.5f;
        }
        if (!agent.isStopped) {
            animator.SetBool("IsMoving", true);
            animator.SetBool("IsRunning", true);
            agent.SetDestination(player.position);
        }
        

    }
}
