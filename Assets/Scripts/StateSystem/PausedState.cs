using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedState : GameState
{
    public PausedState(StateMachine manager) : base(manager) { }

    public override void Enter()
    {
        var uiManager = ServiceLocator.Instance.GetService<UIManager>();
        Debug.Log("Entering Paused State");
        Time.timeScale = 0f; 
        uiManager?.ShowPauseMenu();
    }
    public override void Execute()
    {
        Debug.Log("Not Used");
    }
    public override void Exit()
    {
        var uiManager = ServiceLocator.Instance.GetService<UIManager>();
        Debug.Log("Exiting Paused State");
        Time.timeScale = 1f;
        uiManager?.HideAllMenus();
    }
}