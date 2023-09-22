using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClothingItemType { Shirt, Pants, Hat, Gloves, Shoes }
public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;

    [SerializeField] private PurchaseManager purchase;
    [SerializeField] private PlayerController player;
    [SerializeField] private ClothesEquipper equipper;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private InteractiveObject cashRegister;
    [SerializeField] private PlayerInventorySO playerInventory;
    [SerializeField] private PlayerDataSO playerData;    

    private InteractiveObject activeItem;

    public PurchaseManager Purchase => purchase;
    public PlayerController Player => player;
    public InteractiveObject ActiveItem => activeItem;
    public PlayerInventorySO Inventory => playerInventory;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        player.Initialize();
        purchase.Initialize();
        uiManager.Initialize(purchase.Money);        

        purchase.OnPurchaseDoneInt.AddListener(uiManager.SetMoneyAmountText);

        cashRegister.OnPlayerEntered.AddListener(ApproachRegister);        
        cashRegister.OnPlayerLeft.AddListener(LeaveRegister);
        cashRegister.OnItemUsed.AddListener(LeaveRegister);
        cashRegister.OnItemUsed.AddListener(UseCashRegister);

        equipper.OnItemEquipped.AddListener(SaveProgress);
        purchase.OnPurchaseDone.AddListener(SaveProgress);
        
        purchase.Money = playerData.money;
        player.EquipItem(playerData.equippedShirt);
        player.EquipItem(playerData.equippedPants);
        player.EquipItem(playerData.equippedGloves);
        player.EquipItem(playerData.equippedShoes);

        uiManager.SetMoneyAmountText(purchase.Money);
    }

    private void SaveProgress()
    {
        playerData.SaveData(
            purchase.Money,
            equipper.GetEquippedItem(ClothingItemType.Shirt),
            equipper.GetEquippedItem(ClothingItemType.Pants),
            equipper.GetEquippedItem(ClothingItemType.Gloves),
            equipper.GetEquippedItem(ClothingItemType.Shoes));
    }

    public void SetActiveItem(InteractiveObject item)
    {
        activeItem = item;        
        if (item.GetType() == typeof(SoldItem))
        {
            ShowPopUpForItemEquip(((SoldItem)item).ClothingItem);
        }        
    }

    public void ClearActiveItem(InteractiveObject item)
    {
        if (activeItem == item)
        {
            activeItem = null;
            HidePopUpForItemEquip();
        }        
    }

    public void UseActiveItem()
    {
        if (activeItem != null)
        {
            activeItem.UseItem();
        }
    }

    private void ApproachRegister()
    {
        int totalCost = equipper.GetEquippedItemsTotalCost();
        if (totalCost > 0 && totalCost <= purchase.Money)
        {
            uiManager.ShowUseRegisterPanel(totalCost);
        }
        else if (totalCost > 0)
        {
            uiManager.ShowCantAffordPanel(totalCost);
        }
    }

    private void LeaveRegister()
    {
        uiManager.HideUseRegisterPanel();
        uiManager.HideCantAffordPanel();
    }

    private void UseCashRegister()
    {
        purchase.PurchaseItems(equipper.GetEquipedItems());
    }

    public void ShowPopUpForItemEquip(ClothingItemSO clothingItem)
    {
        HidePopUpForItemEquip();
        if (Inventory.PlayerOwnsItem(clothingItem))
        {
            uiManager.ShowEquipOwnedItemPanel();            
        }
        else
        {
            uiManager.ShowEquipItemPanel(clothingItem.cost);
        }
    }

    public void HidePopUpForItemEquip()
    {
        uiManager.HideItemToEquipPanel();
        uiManager.HideEquipOwnedItemPanel();
    }
}
