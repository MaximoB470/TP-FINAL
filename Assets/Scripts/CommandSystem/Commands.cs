using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Commands/Logs Seconds From Start")]
public class LogSecondsFromStartCmd : Command
{
    private PlayerController controller;
    public override void Execute()
    {
        Debug.Log(Time.realtimeSinceStartup);
    }
    public override void Execute(string[] args)
    {
        Debug.Log(Time.realtimeSinceStartup);
    }
}

    

