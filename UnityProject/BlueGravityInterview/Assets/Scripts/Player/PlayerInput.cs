using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent onUseKeyPressed;

    private float inputX;
    private float inputY;

    public float InputX => inputX;
    public float InputY => inputY;

    private void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.F))
        {
            onUseKeyPressed?.Invoke();
        }
    }
}
