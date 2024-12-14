using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VictoryState : GameState
{
    public VictoryState(StateMachine manager) : base(manager) { }

    public override void Enter()
    {
        var uiManager = ServiceLocator.Instance.GetService<UIManager>();
        var audioService = ServiceLocator.Instance.GetService<IAudioService>();
        audioService.StopBackgroundMusic();
        uiManager?.ShowVictoryMenu();
        Time.timeScale = 0f;  
    }
    public override void Execute()
    {
        Debug.Log("Executing Victory State");
    }
    public override void Exit()
    {
        Debug.Log("Exiting Victory State");
    }
}