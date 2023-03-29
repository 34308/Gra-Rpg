using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class enemyHealthController : MonoBehaviour
{
    Animator animator;
    public float hp=10;
    // Start is called before the first frame update
    void Start()
    {
        if (name.Contains("slime"))
        {
            hp = 10;
        }else if (name.Contains("stone"))
        {
            hp = 50;

        }
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
            if (name.Contains("slime"))
            {
                GetComponent<FollowingUser>().EnemyDead();
            }else if (name.Contains("stone"))
            {
                GetComponent<StoneSnakeMoving>().EnemyDead();

            }
            
           
        };
    }
}
