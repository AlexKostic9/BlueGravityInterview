using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbodyComponent;
    [SerializeField] private Animator animatorComponent;
    [SerializeField] private ClothesEquipper equipper;
    [SerializeField] private PlayerInput input;
    [SerializeField] private float playerSpeed;

    private SoldItem approachedItem;

    //TODO: Remove. Create an Initialize method
    private void Start()
    {
        //TODO: Subscribe only when entering usable item radius
        input.onUseKeyPressed.AddListener(EquipApproachedItem);
    }

    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector2(input.InputX, input.InputY) * Time.fixedDeltaTime * playerSpeed;
        animatorComponent.SetBool("walking", rigidbodyComponent.velocity.magnitude > 0.1f);  
        if (input.InputX != 0)
        {
            HandlePlayerRotation();
        }
    }

    private void EquipApproachedItem()
    {
        if (approachedItem == null)
        {
            return;
        }        

        equipper.EquipItem(approachedItem.ClothingItem);        
    }

    private void HandlePlayerRotation()
    {
        transform.rotation = Quaternion.Euler(0, input.InputX > 0 ? 0 : 180f, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SoldItem soldItem = other.GetComponent<SoldItem>();
        if (soldItem != null)
        {
            if (approachedItem != null)
            {
                approachedItem.PlayerWalkedAway();
            }
            soldItem.PlayerApproached();
            approachedItem = soldItem;            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        SoldItem soldItem = other.GetComponent<SoldItem>();
        if (soldItem != null && approachedItem == soldItem)
        {
            soldItem.PlayerWalkedAway();
            approachedItem = null;
        }
    }
}
