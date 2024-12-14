using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Commands/Heal")]
public class HealCommand : Command
{
    [SerializeField] private int healAmount = 30;
    public override void Execute()
    {
        GameObject player = GameObject.FindGameObjectWithTag("player");
        HealthHandler wrapper = player.GetComponent<HealthHandler>();
        wrapper.Heal(healAmount);
    }
    public override void Execute(string[] args)
    {
        GameObject player = GameObject.FindGameObjectWithTag("player");
        HealthHandler wrapper = player.GetComponent<HealthHandler>();
        wrapper.Heal(healAmount);
    }
}
