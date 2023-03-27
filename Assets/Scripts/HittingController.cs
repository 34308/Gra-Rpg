using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingController : MonoBehaviour
{
    bool isHitting=false;
    private LifeAndManaSystem LifeAndManaSystem;
    public GameObject _explosion;

    // Start is called before the first frame update
    void Start()
    {
        LifeAndManaSystem=GetComponent<LifeAndManaSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void physicalAttack()
    {
        isHitting = true;
    }
    void OnCollisionEnter(Collision collision)
    {
        Collider myCollider = collision.GetContact(0).thisCollider;
        // Now do whatever you need with myCollider.
        // (If multiple colliders were involved in the collision, 
        // you can find them all by iterating through the contacts)
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Enemy"))
        {
            if (isHitting)
            {
                Debug.Log("e2");
                other.gameObject.GetComponent<enemyHealthController>().takeDemage(2);
                isHitting = false;
            }

        }
    }

    public void MagicAttack()
    {
        if (LifeAndManaSystem.mp > 3)
        {
            LifeAndManaSystem.takeMana(3);
            Vector3 attackPosition =GameObject.FindGameObjectWithTag("Pointer").transform.position;
            GameObject goExplosion=Instantiate(_explosion, attackPosition, Quaternion.identity);
            CallAfterDelay.Create(0.5f, () =>
            {
                Destroy(goExplosion);
            });
        }
    }
}
