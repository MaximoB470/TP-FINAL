using System;
using UnityEngine;
using static UnityEngine.UI.Image;

public class HealthHandler : MonoBehaviour, IHealth
{
    private IHealth currentHealthDecorator;

    public IHealth Health;

    public int Life
    {
        get => Health.Life;
        set => Health.Life = value;
    }
    public int maxHp;
    public void Awake()
    {
        currentHealthDecorator = this;
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
    public void SetDecorator(IHealth decorator)
    {
        currentHealthDecorator = decorator;
    }
    public void RemoveDecorator()
    {
        currentHealthDecorator = this;
    }
    
    public class InvulnerableHandler
    {
        private HealthHandler healthHandler;
        private IHealth originalHealth;
        private IHealth invulnerableHealth;

        public InvulnerableHandler(HealthHandler healthHandler)
        {
            this.healthHandler = healthHandler;
            this.originalHealth = healthHandler; 
            this.invulnerableHealth = new InvulnerableHealth(originalHealth);
        }
        public void ApplyInvulnerability()
        {
            healthHandler.SetDecorator(invulnerableHealth);
            Debug.Log("Invulnerability applied.");
        }

        public void RemoveInvulnerability()
        {
            healthHandler.SetDecorator(originalHealth);
            Debug.Log("Invulnerability removed.");
        }
    }
}