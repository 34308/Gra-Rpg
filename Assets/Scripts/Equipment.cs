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
    public int manaPointsFromMixture = 10;
    public int healthPointsFromMixture = 10;
    private IEnumerable<Image> _itemSlots;
    private LifeAndManaSystem _lifeAndManaSystem;
    public bool EquipmentIsFull => _itemSlots.Count(x => x.enabled) == _itemSlots.Count();

    // Start is called before the first frame update
    void Start()
    {
        _itemSlots = inventory.GetComponentsInChildren<Image>().Where(x => x.CompareTag("ItemSlot"));
        _lifeAndManaSystem = gameObject.GetComponent<LifeAndManaSystem>();
        if(_lifeAndManaSystem == null) Debug.LogError("Cant find component LifeAndManaSystem");
        foreach (var itemImage in _itemSlots)
        {
            itemImage.enabled = false;
        }
    }

    void Update()
    {
        HandleUseItem(KeyCode.Alpha1.ToString(), 0);
        HandleUseItem(KeyCode.Alpha2.ToString(), 1);
        HandleUseItem(KeyCode.Alpha3.ToString(), 2);
        HandleUseItem(KeyCode.Alpha4.ToString(), 3);
    }
    
    private void HandleUseItem(string buttonName, int elementIndex)
    {
        if (!Input.GetButtonDown(buttonName)) return;
        var selectedItem = _itemSlots?.ElementAtOrDefault(elementIndex);
        if (!selectedItem || selectedItem.enabled == false) return;
        if (selectedItem.sprite.Equals(manaMixtureSprite) && !_lifeAndManaSystem.MpIsFull)
        {
            _lifeAndManaSystem.RestoreMana(manaPointsFromMixture);
            selectedItem.enabled = false;
        }
        if (selectedItem.sprite.Equals(healthMixtureSprite) && !_lifeAndManaSystem.HpIsFull)
        {
            _lifeAndManaSystem.HealPlayer(healthPointsFromMixture);
            selectedItem.enabled = false;
        }
    }

    public void PickupItem(ItemType type)
    {
        var firstEmptySlot = _itemSlots.FirstOrDefault(s => s.enabled == false);
        if (firstEmptySlot == null) return;
        firstEmptySlot.sprite = ChooseSpriteForEquipmentType(type);
        firstEmptySlot.enabled = true;
    }

    private Sprite ChooseSpriteForEquipmentType(ItemType type)
    {
        switch (type)
        {
            case ItemType.HealthPoints:
                return healthMixtureSprite;
            case ItemType.ManaPoints:
                return manaMixtureSprite;
            default:
                return default;
        }
    }

    // public class ItemSlot
    // {
    //     public Image Image { get; set; }
    //     public ItemType ItemType { get; set; }
    // }

    public enum ItemType
    {
        HealthPoints,
        ManaPoints
    }
}
