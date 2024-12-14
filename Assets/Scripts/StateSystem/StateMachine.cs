using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine 
{
    public GameState currentState;

    public void Update()
    {
        if (currentState != null)
        {
            currentState.Execute();
        }
    }
    public void ChangeState(GameState newState)
    {
        if (currentState == newState) return; 
        currentState?.Exit(); 
        currentState = newState;
        currentState?.Enter(); 
    }
}
