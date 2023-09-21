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
    
    public void Initialize()
    {
        input.onUseKeyPressed.AddListener(GameplayManager.Instance.UseActiveItem);
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

    public void EquipItem(ClothingItemSO item)
    {
        equipper.EquipItem(item);        
    }

    private void HandlePlayerRotation()
    {
        transform.rotation = Quaternion.Euler(0, input.InputX > 0 ? 0 : 180f, 0);
    }    
}
