using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseManager : MonoBehaviour
{
    [SerializeField] private int moneyOnStart;
    [SerializeField] private PlayerInventorySO playerInventory;

    private int money;

    public void Initialize()
    {
        money = moneyOnStart;
    }

    public void PurchaseItems(ClothingItemSO[] items)
    {
        List<ClothingItemSO> itemsToPurchase = new List<ClothingItemSO>();
        int totalCost = 0;
        for(int i = 0; i < items.Length; i++)
        {
            if (!playerInventory.PlayerOwnsItem(items[i]))
            {
                itemsToPurchase.Add(items[i]);
                totalCost += items[i].cost;
            }            
        }

        if (totalCost > money)
        {
            return;
        } 
        else
        {
            money -= totalCost;
            playerInventory.AddOwnedItems(itemsToPurchase);
        }
    }
}
