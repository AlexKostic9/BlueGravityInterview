using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;

    [SerializeField] private PurchaseManager purchase;
    [SerializeField] private PlayerController player;
    [SerializeField] private ClothesEquipper equipper;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private InteractiveObject cashRegister;
    [SerializeField] private PlayerInventorySO playerInventory;

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
        purchase.OnPurchaseDone.AddListener(uiManager.SetMoneyAmountText);

        cashRegister.OnPlayerEntered.AddListener(ApproachRegister);        
        cashRegister.OnPlayerLeft.AddListener(LeaveRegister);
        cashRegister.OnItemUsed.AddListener(LeaveRegister);
        cashRegister.OnItemUsed.AddListener(UseCashRegister);
    }

    public void SetActiveItem(InteractiveObject item)
    {
        activeItem = item;
    }

    public void ClearActiveItem(InteractiveObject item)
    {
        if (activeItem == item)
        {
            activeItem = null;
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
        else
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
}
