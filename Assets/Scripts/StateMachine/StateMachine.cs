using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private IState currentlyRunningState;
    private IState previousState;

    public void ChangeState(IState _newState)
    {
        if (currentlyRunningState != null)
            currentlyRunningState.Exit();

        currentlyRunningState = _newState;
        currentlyRunningState.Enter();
    }

    public void ExecuteStateUpdate()
    {
        if (currentlyRunningState != null)
            currentlyRunningState.Execute();
    }

    public IState GetCurrentState()
    {
        return currentlyRunningState;
    }
}
