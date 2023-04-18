using UnityEngine;
using UnityEngine.UI;
public class LifeAndManaSystem : MonoBehaviour
{
    private const int MaxHp = 10;
    public int hp=10;
    private const int MaxMp = 10;
    public int mp = 10;
    [SerializeField]
    public Slider hpBar;
    [SerializeField]
    public Slider mpBar;
    public GameObject EndingScreen;
    public GameObject deathMessage;
    public GameObject WinningMessage;
    // Start is called before the first frame update
    public bool HpIsFull => MaxHp == hp;
    public bool MpIsFull => MaxMp == mp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDemage(int demage)
    {
        hp = hp - demage;
        if (hp <= 0)
        {
            Die();
        }
        hpBar.value = (hp * 100.0f / MaxHp) / 100.0f;
    }
    public void HealPlayer(int heal)
    {
        
        hp = hp + heal;
        if (hp > MaxHp)
        {
            hp = MaxHp;
        }
        hpBar.value = (hp * 100 / MaxHp)/100.0f;
    }
    public void takeMana(int cost)
    {
        mp = mp - cost;
        mpBar.value = (mp * 100 / MaxMp)/ 100.0f;
    }
    public void RestoreMana(int restore)
    {

        mp = mp + restore;
        if (mp > MaxMp)
        {
            mp = MaxMp;
        }
        mpBar.value = (mp * 100 / MaxMp)/100.0f;
    }

    private void Die()
    {
        deathMessage.SetActive(true);
        EndingScreen.SetActive(true);
        GetComponent<TopDownCharacterMover>().Dead();
        GetComponent<Animator>().SetBool("isAlive",false);
        
    }
    public void Won()
    {
        WinningMessage.SetActive(true);
        EndingScreen.SetActive(true);
    }
}
