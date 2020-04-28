using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_FiniteStateMachine
{
    public SC_State currentState { get; private set; }

    public void Initialize(SC_State startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }

    public void ChangeState(SC_State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
