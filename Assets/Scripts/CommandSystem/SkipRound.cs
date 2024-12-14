using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Commands/SkipRound")]
public class SkipRound : Command
{
    public override void Execute()
    {
        var gameManager = ServiceLocator.Instance.GetService<GameManager>();
        gameManager.ForceWave = true;
    }
    public override void Execute(string[] args)
    {
        var gameManager = ServiceLocator.Instance.GetService<GameManager>();
        gameManager.ForceWave = true;
    }
}
