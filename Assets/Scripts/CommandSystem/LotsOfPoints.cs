using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Commands/LotsOfPoints")]
public class LotsOfPoints : Command
{
    public override void Execute()
    {
       var scoreManager = ServiceLocator.Instance.GetService<ScoreManager>();
        scoreManager.value += scoreManager.commandValue;
        Debug.Log("Applying points");
    }
    public override void Execute(string[] args)
    {
        var scoreManager = ServiceLocator.Instance.GetService<ScoreManager>();
        scoreManager.value += scoreManager.commandValue;
        Debug.Log("Applying points");
    }
}