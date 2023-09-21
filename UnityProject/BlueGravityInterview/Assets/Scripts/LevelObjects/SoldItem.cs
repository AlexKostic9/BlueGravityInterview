using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldItem : InteractiveObject
{    
    [SerializeField] private SpriteRenderer rendererComponent;
    [SerializeField] private ClothingItemSO clothingItem;

    public ClothingItemSO ClothingItem => clothingItem;

    private void OnValidate()
    {
        rendererComponent.sprite = clothingItem.sprite;
    }
    
    public override void UseItem()
    {
        base.UseItem();
        GameplayManager.Instance.Player.EquipItem(clothingItem);
    }    
}
