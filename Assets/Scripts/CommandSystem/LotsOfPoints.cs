using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Commands/LotsOfPoints")]
public class LotsOfPoints : Command
{
    public override void Execute()
    {
       var playerController = ServiceLocator.Instance.GetService<PlayerController>();
       playerController.points = 99999999;
       Debug.Log("Applying points");
    }
    public override void Execute(string[] args)
    {
        var playerController = ServiceLocator.Instance.GetService<PlayerController>();
        playerController.points = 99999999;
        Debug.Log("Applying points");
    }
}