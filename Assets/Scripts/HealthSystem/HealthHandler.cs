using System;
using UnityEngine;
using static UnityEngine.UI.Image;

public class HealthHandler: MonoBehaviour, IHealth
{
    public IHealth Health;
    public int Life
    {
        get => Health.Life;
        set => Health.Life = value;
    }
    public int maxHp;
    public void Awake()
    {
        Health = new Health();
        Life = maxHp;
    }
 
    public void GetDamage(int value) 
    {
        Health.GetDamage(value);

        if (Health.Life <= 0) 
        {
            Debug.Log("Dead");
        }
    }
    public void Heal(int HA) 
    {
        var audioService = new AudioService();
        ServiceLocator.Instance.Register<IAudioService>(audioService);
        audioService.HealSound();
        Health.Life += HA;
    }
}
public class InvulnerableHandler
{
    //We want to change it's health variable to add logic to it
    HealthHandler healthHandler;
    public void ApplyInvulnerability(HealthHandler healthHandler)
    {
        var original = healthHandler.Health;
        IHealth invulnerableHealth = new InvulnerableHealth(original);
        healthHandler.Health = invulnerableHealth;
    }
}