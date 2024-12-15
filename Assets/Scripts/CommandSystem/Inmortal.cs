using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static HealthHandler;

[CreateAssetMenu(menuName = "Commands/Inmortal")]
public class Inmortal : Command
{
    private InvulnerableHandler invulnerableHandler;

    public override void Execute()
    {
        var playerController = ServiceLocator.Instance.GetService<PlayerController>();
        HealthHandler healthHandler = playerController.GetComponent<HealthHandler>();

        if (healthHandler != null)
        {
            if (invulnerableHandler == null)
            {
                invulnerableHandler = new InvulnerableHandler(healthHandler);
            }

            invulnerableHandler.ApplyInvulnerability();
        }
    }
    public override void Execute(string[] args)
    {
        Execute();
    }
}