using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StoneSnakeMoving : MonoBehaviour
{
    NavMeshAgent agent;
    int stopping_distance = 20;
    private NavMeshAgent enemy;
    private Transform player;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = stopping_distance;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(enemy.isStopped);
        if (!enemy.isStopped) {
            
            animator.SetBool("IsMoving", true);
            animator.SetBool("IsRunning", true);
        }
        else if(enemy.isStopped){
            enemy.Move(player.position);
        }
        enemy.SetDestination(player.position);

    }
}
