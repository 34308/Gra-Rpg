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
        CallAfterDelay.Create(0.5f, () =>
        {
            isHitting = false;
        });
    }
    void OnCollisionEnter(Collision collision)
    {
        Collider myCollider = collision.GetContact(0).thisCollider;
   
    }
    private void OnTriggerStay(Collider other)
    {
       
        if (other.gameObject.CompareTag("Enemy"))
        {
          
            if (isHitting)
            {
                Debug.Log(other.gameObject.name);
                other.gameObject.GetComponent<EnemyHealthController>().TakeDamage(2);
                GetComponent<LifeAndManaSystem>().restoreMana(1);
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
