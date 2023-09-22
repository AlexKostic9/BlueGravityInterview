using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "New Player Data", order = 2)]
public class PlayerDataSO : ScriptableObject
{
    public int money;
    public ClothingItemSO equippedShirt;
    public ClothingItemSO equippedPants;
    public ClothingItemSO equippedGloves;
    public ClothingItemSO equippedShoes;

    public void SaveData(int money, ClothingItemSO shirt, ClothingItemSO pants, ClothingItemSO gloves, ClothingItemSO shoes)
    {
        this.money = money;
        if (shirt != null)
        {
            equippedShirt = shirt;
        }        
        if (pants != null)
        {
            equippedPants = pants;
        }        
        if (gloves != null)
        {
            equippedGloves = gloves;
        }        
        if (shoes != null)
        {
            equippedShoes = shoes;
        }        
    }
}
