using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClothingItem", menuName = "Clothing Items/New Clothing Item", order = 0)]
public class ClothingItemSO : ScriptableObject
{
    public string itemID;
    public ClothingItemType itemType;
    public int cost;
    public Sprite sprite;
}
