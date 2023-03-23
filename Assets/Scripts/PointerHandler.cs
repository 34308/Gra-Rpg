using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PointerHandler : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    // Start is called before the first frame update
    void Start()

    {
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
}
