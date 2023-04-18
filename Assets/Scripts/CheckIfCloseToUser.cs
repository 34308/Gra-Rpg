using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfCloseToUser : MonoBehaviour
{
    Animator _animator;
    GameObject _player;

    private static readonly int IsCloseToPlayer = Animator.StringToHash("isCloseToPlayer");

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoDamage()
    {
        if (_animator.GetBool(IsCloseToPlayer))
        {
            _player.GetComponent<LifeAndManaSystem>().takeDemage(2);
        } 
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _animator.SetBool(IsCloseToPlayer, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            _animator.SetBool(IsCloseToPlayer, false);
            
        }
    }
}
