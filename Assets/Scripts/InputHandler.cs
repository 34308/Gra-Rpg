using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class InputHandler : MonoBehaviour
{
    public Vector2 InputVector { get; private set; }
    public bool sprint { get; private set; }
    public bool physicalAttack { get; private set; }
    public bool magicAttack { get; private set; }
    public Vector3 MousePosition { get; private set; }
    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        if (Input.GetMouseButtonDown(0))
        {
            physicalAttack = true;
        }
        else if (Input.GetMouseButtonUp(0)) {
            physicalAttack = false;
        };
        if (Input.GetMouseButtonDown(1))
        {
            magicAttack = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            
            GameObject.FindGameObjectWithTag("Player").GetComponent<HittingController>().MagicAttack();
            magicAttack = false;
        };
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprint = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprint = false;
        }
        InputVector = new Vector2(h, v);

    }
}
