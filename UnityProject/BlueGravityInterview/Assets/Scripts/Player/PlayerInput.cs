using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent onUseKeyPressed;
    public UnityEvent onMovementKeyPressed;

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

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            onMovementKeyPressed?.Invoke();
        }
    }
}
