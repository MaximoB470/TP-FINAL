using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatState : GameState
{
    public DefeatState(StateMachine manager) : base(manager) { }
    public override void Enter()
    {
        Debug.Log("Entering Defeat State");
        var audioService = ServiceLocator.Instance.GetService<IAudioService>();
        var uiManager = ServiceLocator.Instance.GetService<UIManager>();

        if (audioService != null)
        {
            audioService.StopBackgroundMusic();
        }
        if (uiManager != null)
        {
            uiManager.ShowDefeatMenu();
        }
        Time.timeScale = 0f; 
    }
    public override void Execute()
    {
        Debug.Log("Not Used");
    }

    public override void Exit()
    {
        Debug.Log("Exiting Defeat State");
    }
}