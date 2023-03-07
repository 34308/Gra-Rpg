using UnityEngine;
using UnityEngine.UI;
public class LifeAndManaSystem : MonoBehaviour
{
    int maxHp = 10;
    public int hp=10;
    int maxMp = 10;
    public int mp = 10;
    public Slider hpBar;
    public Slider mpBar;
    // Start is called before the first frame update
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
        hpBar.value = (hp * 100.0f / maxHp) / 100.0f;
    }
    public void healPlayer(int heal)
    {
        
        hp = hp + heal;
        if (hp > maxHp)
        {
            hp = maxHp;
        }
        hpBar.value = (hp * 100 / maxHp)/100.0f;
    }
    public void takeMana(int cost)
    {
        mp = mp - cost;
        mpBar.value = (mp * 100 / maxMp)/ 100.0f;
    }
    public void restoreMana(int restore)
    {

        mp = mp + restore;
        if (mp > maxMp)
        {
            mp = maxMp;
        }
        mpBar.value = (mp * 100 / maxMp)/100.0f;
    }
}
