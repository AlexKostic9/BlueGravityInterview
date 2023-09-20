using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingOrderSetter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] rendererComponents;
    [SerializeField] private Transform groundTouchPoint;

    //TODO: Should be global
    [SerializeField] private float unitsPerLayer;

    //TODO: Should only be called when position changes
    private void Update()
    {
        UpdateSortingOrder();
    }

    public void UpdateSortingOrder()
    {
        if (unitsPerLayer > 0)
        {
            int order = -Mathf.RoundToInt(groundTouchPoint.position.y / unitsPerLayer);
            foreach (SpriteRenderer renderer in rendererComponents)
            {
                renderer.sortingOrder = order;
            }
        }        
    }
}
