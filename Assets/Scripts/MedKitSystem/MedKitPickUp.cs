using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MedKitPickUp : MonoBehaviour, Iinteractable
{
    [SerializeField] private int healAmount = 10; 
    private MedKit medKit;
    public void Initialize(MedKit medKit)
    {
        this.medKit = medKit;
    }
    private void Start()
    {
        var medKitFactory = ServiceLocator.Instance.GetService<MedKitFactory>();
        if (medKitFactory != null)
        {
            medKit = medKitFactory.GetMedKit(healAmount);
        }
    }
    public void interaction()
    {
        var player = ServiceLocator.Instance.GetService<PlayerController>();
        if (player != null && medKit != null)
        {
            medKit.Use(player);
            gameObject.SetActive(false); 
        }
    }
}