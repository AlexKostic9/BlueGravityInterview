using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;

    [SerializeField] private PurchaseManager purchase;

    public PurchaseManager Purchase => purchase;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        purchase.Initialize();
    }
}
