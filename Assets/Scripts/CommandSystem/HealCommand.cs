using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Commands/Heal")]
public class HealCommand : Command
{
    [SerializeField] private int healAmount = 30;
    public override void Execute()
    {
        var playerController = ServiceLocator.Instance.GetService<PlayerController>();
        HealthHandler wrapper = playerController.GetComponent<HealthHandler>();
        wrapper.Heal(healAmount);
    }
    public override void Execute(string[] args)
    {
        var playerController = ServiceLocator.Instance.GetService<PlayerController>();
        HealthHandler wrapper = playerController.GetComponent<HealthHandler>();
        wrapper.Heal(healAmount);
    }
}
