using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class Equipment : MonoBehaviour
{
    public Sprite manaMixtureSprite;
    public Sprite healthMixtureSprite;
    public GameObject inventory;
    private IEnumerable<Image> _itemImages;
    // Start is called before the first frame update
    void Start()
    {
        // _itemImages = inventory.FindAllComponentsInChildWithTag<Image>("EquipmentIcon");
        _itemImages = inventory.GetComponentsInChildren<Image>().Where(x => x.sprite == null);
        foreach (var itemImage in _itemImages)
        {
            if (itemImage.sprite == null) itemImage.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PickupItem(EquipmentType type)
    {
        Console.Out.WriteLine("Took Item");
        foreach (var itemImage in _itemImages)
        {
            if (itemImage.sprite == null)
            {
                itemImage.sprite = ChooseSpriteForEquipmentType(type);
            }
        }
    }

    private Sprite ChooseSpriteForEquipmentType(EquipmentType type)
    {
        switch (type)
        {
            case EquipmentType.HealthPoints:
                return healthMixtureSprite;
            case EquipmentType.ManaPoints:
                return manaMixtureSprite;
            default:
                return default;
        }
    }

    enum EquipmentType
    {
        HealthPoints,
        ManaPoints
    }
}
