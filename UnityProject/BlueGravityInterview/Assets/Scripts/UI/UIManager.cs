using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text_Money;

    [SerializeField] private Animator panel_UseRegister;
    [SerializeField] private Animator panel_CantAfford;
    [SerializeField] private Animator panel_EquipItem;
    [SerializeField] private Animator panel_EquipOwnedItem;

    [SerializeField] private TextMeshProUGUI text_UseRegisterCost;
    [SerializeField] private TextMeshProUGUI text_CantAffordTotalCost;
    [SerializeField] private TextMeshProUGUI text_ItemToEquipCost;
    [SerializeField] private TextMeshProUGUI text_ItemOwnedName;

    public void Initialize(int moneyAmount)
    {
        SetMoneyAmountText(moneyAmount);
    }

    public void SetMoneyAmountText(int amount)
    {
        text_Money.text = $"Money: {amount}";
    }

    public void ShowUseRegisterPanel(int totalCost)
    {
        text_UseRegisterCost.text = $"Total Cost: {totalCost}";
        panel_UseRegister.SetBool("active", true);
    }

    public void HideUseRegisterPanel()
    {
        panel_UseRegister.SetBool("active", false);
    }

    public void ShowCantAffordPanel(int totalCost)
    {
        text_CantAffordTotalCost.text = $"Required: {totalCost}";
        panel_CantAfford.SetBool("active", true);
    }

    public void HideCantAffordPanel()
    {
        panel_CantAfford.SetBool("active", false);
    }

    public void ShowEquipItemPanel(int cost)
    {
        text_ItemToEquipCost.text = $"Item Cost: {cost}";
        panel_EquipItem.SetBool("active", true);
    }

    public void HideItemToEquipPanel()
    {
        panel_EquipItem.SetBool("active", false);
    }

    public void ShowEquipOwnedItemPanel()
    {        
        panel_EquipOwnedItem.SetBool("active", true);
    }

    public void HideEquipOwnedItemPanel()
    {
        panel_EquipOwnedItem.SetBool("active", false);
    }
}
