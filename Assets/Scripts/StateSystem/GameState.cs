using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{
    protected StateMachine stateMachine;
    public GameState(StateMachine State)
    {
        stateMachine = State;
    }
    public abstract void Enter();   
    public abstract void Execute(); 
    public abstract void Exit();    
}