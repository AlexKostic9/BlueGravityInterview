using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClothesEquipper : MonoBehaviour
{
    public UnityEvent OnItemEquipped;

    [SerializeField] private SpriteRenderer rendererShirt;
    [SerializeField] private SpriteRenderer rendererPants;
    [SerializeField] private SpriteRenderer rendererHat;
    [SerializeField] private SpriteRenderer[] rendererGloves;
    [SerializeField] private SpriteRenderer[] rendererShoes;

    private ClothingItemSO equippedItemShirt;
    private ClothingItemSO equippedItemPants;
    private ClothingItemSO equippedItemHat;
    private ClothingItemSO equippedItemGloves;
    private ClothingItemSO equippedItemShoes;

    public void EquipItem(ClothingItemSO item)
    {
        switch(item.itemType)
        {
            case ClothingItemType.Shirt:
                rendererShirt.sprite = item.sprite;
                equippedItemShirt = item;
                break;
            case ClothingItemType.Pants:
                rendererPants.sprite = item.sprite;
                equippedItemPants = item;
                break;
            case ClothingItemType.Hat:
                rendererHat.sprite = item.sprite;
                equippedItemHat = item;
                break;
            case ClothingItemType.Gloves:
                rendererGloves[0].sprite = item.sprite;
                rendererGloves[1].sprite = item.sprite;
                equippedItemGloves = item;
                break;
            case ClothingItemType.Shoes:
                rendererShoes[0].sprite = item.sprite;
                rendererShoes[1].sprite = item.sprite;
                equippedItemShoes = item;
                break;
            default: break;
        }
        OnItemEquipped?.Invoke();
    }

    public ClothingItemSO GetEquippedItem(ClothingItemType type)
    {
        switch (type)
        {
            case ClothingItemType.Shirt:
                return equippedItemShirt;                
            case ClothingItemType.Pants:
                return equippedItemPants;
            case ClothingItemType.Hat:
                return equippedItemHat;                
            case ClothingItemType.Gloves:
                return equippedItemGloves;
            case ClothingItemType.Shoes:
                return equippedItemShoes;
            default: return null;
        }
    }

    public List<ClothingItemSO> GetEquipedItems()
    {
        List<ClothingItemSO> equipped = new List<ClothingItemSO>();
        if (equippedItemShirt != null) equipped.Add(equippedItemShirt);
        if (equippedItemPants != null) equipped.Add(equippedItemPants);
        if (equippedItemHat != null) equipped.Add(equippedItemHat);
        if (equippedItemGloves != null) equipped.Add(equippedItemGloves);
        if (equippedItemShoes != null) equipped.Add(equippedItemShoes);
        return equipped;
    }

    public int GetEquippedItemsTotalCost()
    {
        List<ClothingItemSO> equipped = GetEquipedItems();
        int totalCost = 0;
        foreach(ClothingItemSO item in equipped)
        {
            if (!GameplayManager.Instance.Inventory.PlayerOwnsItem(item))
            {
                totalCost += item.cost;
            }            
        }
        return totalCost;
    }
}
