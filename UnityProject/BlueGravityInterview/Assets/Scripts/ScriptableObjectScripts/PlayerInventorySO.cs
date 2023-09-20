using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerInventory", menuName ="New Player Inventory", order = 1)]
public class PlayerInventorySO : ScriptableObject
{
    public List<ClothingItemSO> ownedItems;

    public bool PlayerOwnsItem(ClothingItemSO item)
    {
        return ownedItems.Contains(item);
    }

    public void AddOwnedItems(List<ClothingItemSO> itemsToAdd)
    {
        foreach(ClothingItemSO item in itemsToAdd)
        {
            if (!PlayerOwnsItem(item))
            {
                ownedItems.Add(item);
            }
        }
    }
}
