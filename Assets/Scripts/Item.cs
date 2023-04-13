using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Equipment.ItemType itemType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var equipment = other.GetComponentInParent<Equipment>();
        if (equipment != null && !equipment.EquipmentIsFull)
        {
            equipment.PickupItem(itemType);
            gameObject.SetActive(false);
        }
    }
}
