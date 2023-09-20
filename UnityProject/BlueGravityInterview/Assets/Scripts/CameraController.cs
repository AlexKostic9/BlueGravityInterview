using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float cameraSpeed;

    private void FixedUpdate()
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, cameraSpeed * Time.fixedDeltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
        }
    }
}
