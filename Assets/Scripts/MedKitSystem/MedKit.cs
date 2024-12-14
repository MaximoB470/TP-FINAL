using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit
{
    private int healAmount; 
    public MedKit(int healAmount)
    {
        this.healAmount = healAmount;
    }
    public void Use(PlayerController player)
    {
        var healthHandler = player.GetComponent<HealthHandler>();
        if (healthHandler != null)
        {
            healthHandler.Heal(healAmount); 
        }
    }
    public int GetHealAmount() => healAmount;
}