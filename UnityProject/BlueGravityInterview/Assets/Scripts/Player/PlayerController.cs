using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbodyComponent;
    [SerializeField] private PlayerInput input;
    [SerializeField] private float playerSpeed;

    private SoldItem approachedItem;

    //TODO: Move to a Manager class
    [SerializeField] private int startingMoney;
    [SerializeField] private int money;

    //TODO: Remove. Create an Initialize method
    private void Start()
    {
        //TODO: Subscribe only when entering usable item radius
        input.onUseKeyPressed.AddListener(PurchaseApproachedItem);
        money = startingMoney;
    }

    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector2(input.InputX, input.InputY) * Time.fixedDeltaTime * playerSpeed;
    }

    private void PurchaseApproachedItem()
    {
        if (approachedItem == null || money < approachedItem.Cost)
        {
            return;
        }
        //TODO: Temporary. Introduce script responsible for handling the visuals of the player
        GetComponent<SpriteRenderer>().color = approachedItem.GetComponent<SpriteRenderer>().color;
        money -= approachedItem.Cost;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SoldItem soldItem = other.GetComponent<SoldItem>();
        if (soldItem != null)
        {
            approachedItem = soldItem;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        SoldItem soldItem = other.GetComponent<SoldItem>();
        if (soldItem != null)
        {
            approachedItem = null;
        }
    }
}
