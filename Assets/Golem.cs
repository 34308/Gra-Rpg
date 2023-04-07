using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Golem : MonoBehaviour
{
    private bool _isInMeleeRange=false;
    private NavMeshAgent _enemy;
    private bool _canThrow=true;
    Animator _animator;
    private float _howFar;
    private bool _canAttack=true;
    private Transform player;
    private bool isInSlamArea=false;
    private bool isInMegaSlamArea=false;
    private ParticleSystem _particleSystemMana;
    private ParticleSystem _particleSystemGround;
    // Start is called before the first frame update
    void Start()
    {
        Helper.FindComponentInChildWithTag<MeshRenderer>(this.gameObject, "SlamArea").forceRenderingOff=true;
        Helper.FindComponentInChildWithTag<MeshRenderer>(this.gameObject, "MegaSlamArea").forceRenderingOff=true;

        _particleSystemMana= Helper.FindComponentInChildWithTag<ParticleSystem>(this.gameObject,"manaEnemyEffect");

        _particleSystemGround = Helper.FindComponentInChildWithTag<ParticleSystem>(this.gameObject,"GroundEffect");
        _enemy = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        var random = Random.Range(0, 1000);
        _howFar = Vector3.Distance(player.transform.position,transform.position);
        if(random == 2 && _canThrow && _howFar>8 &&_howFar<20)
        {
            _canThrow = false;
            _animator.SetInteger("attack",5);
        }else if (random == 5 && _canThrow && _howFar>8 &&_howFar<20)
        {
            _canThrow = false;
            _animator.SetInteger("attack",2);
        }
        else
        {
            _animator.SetBool("isMoving",true);
            _enemy.SetDestination(player.position);
        }
       
    }

    public void OnHittingColiderActivated()
    {
        _isInMeleeRange=true;
        if (_canAttack)
        {
            _canAttack = false;
            var attack = Random.Range(1, 5);
            if (attack == 2)
            {
                attack = attack+1;
            }
            
            if (attack != 2){
                if (attack == 4)
                {
                    Helper.FindComponentInChildWithTag<MeshRenderer>(this.gameObject, "SlamArea").forceRenderingOff=false;
                    CallAfterDelay.Create(2f, () =>
                    {
                        Helper.FindComponentInChildWithTag<MeshRenderer>(this.gameObject, "SlamArea").forceRenderingOff=true;

                    });
                }else if (attack == 1)
                {
                    Helper.FindComponentInChildWithTag<MeshRenderer>(this.gameObject, "MegaSlamArea").forceRenderingOff=false;
                    CallAfterDelay.Create(2f, () =>
                    {
                        Helper.FindComponentInChildWithTag<MeshRenderer>(this.gameObject, "MegaSlamArea").forceRenderingOff=true;

                    });
                }
                _animator.SetInteger("attack",attack);
                CallAfterDelay.Create(3f, () =>
                {
                    _canAttack = true;
                });
            }
        }
        
    }

    public void PlayManaEffect()
    {
        _particleSystemMana.Play();
    }
    public void OnHittingColiderDeactivated()
    {
        _isInMeleeRange=false;
    }
    public void GolemPunchAttackDamage()
    {
        if (_isInMeleeRange)
        {
            if (Vector3.Distance(player.position, this.transform.position) < 3)
            {
                player.GetComponent<LifeAndManaSystem>().takeDemage(2);
            }
         
        }
    }
    public void IsInSlamArea(bool inArea)
    {
        isInSlamArea = inArea;
        if(Random.Range(0, 10) == 2 && inArea)
        {
            _animator.SetInteger("attack",4);
        }
    }

    public void EnemyDead()
    {
        _enemy.isStopped = true;
        CallAfterDelay.Create(5f, () =>
        {
            Destroy(this.gameObject);
        });
    }
    public void AfterAttack()
    {
        _animator.SetInteger("attack",0);
    }
    //wywolywane w animcji
    public void Throw()
    {
        _canThrow = true;
        GetComponent<PathPrediction>().SpawnPosition(transform.GetChild(8).transform);

        GetComponent<PathPrediction>().shoot();
    }
    public void IsInMegaSlamArea(bool inArea)
    {
       
        
        isInMegaSlamArea = inArea;
        if(Random.Range(0, 10) == 2 &&inArea)
        {
            
            _animator.SetInteger("attack",1);
        }
    }
    public void GolemSlamAttackDamage()
    {
        _particleSystemGround.Play();
        if (isInSlamArea)
        {
            player.GetComponent<LifeAndManaSystem>().takeDemage(3);
        }
    }
    public void GolemMegaSlamAttackDamage()
    {
        _particleSystemGround.Play();
        if (isInMegaSlamArea)
        {
            player.GetComponent<LifeAndManaSystem>().takeDemage(5);
        }
    }

    public void DisableShoot()
    {
        _canThrow = false;
    }
}
