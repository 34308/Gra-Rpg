using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealthController : MonoBehaviour
{
    Animator animator;
    float hp=10;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDemage(int dmg)
    {
        
        hp = hp - dmg;
        if (hp <= 0) {
            animator.SetBool("isAlive", false);
            GetComponent<FollowingUser>().enemyDead();
           
        };
    }
}
