using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayingState : GameState
{
    private StateMachine state;
    private UIManager uiManager;
    public PlayingState(StateMachine manager) : base(manager)
    {
        state = manager; 
    }
    public override void Enter()
    {
        Time.timeScale = 1f;
        Debug.Log("Entering Playing State");
    }
    public override void Execute()
    {
        Debug.Log("Not Used");
    }
    public override void Exit()
    {
        Debug.Log("Exiting Playing State");
    }
}