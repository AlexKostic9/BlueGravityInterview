using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesEquipper : MonoBehaviour
{
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
    }
}
