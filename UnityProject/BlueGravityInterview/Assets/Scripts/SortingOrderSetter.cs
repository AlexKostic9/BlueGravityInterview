using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingOrderSetter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] rendererComponents;
    [SerializeField] private int[] initialOrder;
    [SerializeField] private Transform groundTouchPoint;

    //TODO: Should be global
    [SerializeField] private float unitsPerLayer;

    private void OnValidate()
    {
        initialOrder = new int[rendererComponents.Length];
        for (int i = 0; i < initialOrder.Length; i++)
        {
            initialOrder[i] = rendererComponents[i].sortingOrder;
        }
    }

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
            
            for (int i = 0; i < rendererComponents.Length; i++)
            {
                rendererComponents[i].sortingOrder = initialOrder[i] + order;
            }
        }        
    }
}
