using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private TextMesh smiley;

    public IdleState(TextMesh _smiley)
    {
        smiley = _smiley;
    }

    public void Enter()
    {
        smiley.gameObject.SetActive(false);
    }

    public void Execute()
    {
        //Don't move during an idle state
    }

    public void Exit()
    {
        
    }
}
