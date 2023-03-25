using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PointerHandler : MonoBehaviour
{
    private Material color;
    [SerializeField] private Camera mainCamera;
    // Start is called before the first frame update
    void Start()

    {
        color = GetComponent<Renderer>().material;
        GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
       Ray ray=mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out RaycastHit raycastHit))
        {
            transform.position = raycastHit.point;
        }
    }

    public void TurnGreen()
    
    {
        Debug.Log("green");
        color.SetColor("_Color",Color.green);
    }
    public void TurnRed()
    {
        Debug.Log("red");
        color.SetColor("_Color",Color.red);
    }
    public bool IsRed()
    {
        return color.GetColor("_Color") == Color.red;
    }
    public bool IsGreen()
    {
        return color.GetColor("_Color") == Color.green;
    }
}
