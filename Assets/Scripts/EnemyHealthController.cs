using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EnemyHealthController : MonoBehaviour
{
    public float maxHealth = 10;
    public GameObject healthBarUI;
    public Slider slider;
    private Animator _animator;
    private float _health;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _health = maxHealth;
        slider.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateHealth();
    }

    private float CalculateHealth()
    {
        return _health / maxHealth;
    }
    public void TakeDamage(int dmg)
    {
        _health -= dmg;
        if (_health <= 0) {
            _animator.SetBool("isAlive", false);
            GetComponent<FollowingUser>().EnemyDead();
           return;
        }
        healthBarUI.SetActive(true);
    }

    public void Heal(int hp)
    {
        _health += hp;
        if (_health < maxHealth)
        {
            _health = maxHealth;
        }
    }
}
