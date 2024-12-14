using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Commands/ApplyDash")]
public class ApplyDash : Command
{
    public override void Execute()
    {
        var playerController = ServiceLocator.Instance.GetService<PlayerController>();
        playerController.UnlockDash();
        Debug.Log("Applied Dash");
    }
    public override void Execute(string[] args)
    {
       var playerController = ServiceLocator.Instance.GetService<PlayerController>();
       playerController.UnlockDash();
       Debug.Log("Applied Dash");
    }
}
