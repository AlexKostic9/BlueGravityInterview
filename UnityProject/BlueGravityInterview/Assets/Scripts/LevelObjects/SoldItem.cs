using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldItem : MonoBehaviour
{    
    [SerializeField] private Animator animatorComponent;
    [SerializeField] private SpriteRenderer rendererComponent;
    [SerializeField] private ClothingItemSO clothingItem;

    public ClothingItemSO ClothingItem => clothingItem;

    private void OnValidate()
    {
        rendererComponent.sprite = clothingItem.sprite;
    }

    public void PlayerApproached()
    {
        animatorComponent.SetTrigger("approach");
    }

    public void PlayerWalkedAway()
    {
        animatorComponent.SetTrigger("walkAway");
    }
}
