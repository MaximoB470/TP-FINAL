using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Commands/ForceSkipRound")]
public class ForceSkipRound : Command
{
    public override void Execute()
    {
        var gameManager = ServiceLocator.Instance.GetService<GameManager>();
        gameManager.StartWave();
        gameManager.currentWave++;
    }
    public override void Execute(string[] args)
    {
        var gameManager = ServiceLocator.Instance.GetService<GameManager>();
        gameManager.StartWave();
        gameManager.currentWave++;
    }
}
