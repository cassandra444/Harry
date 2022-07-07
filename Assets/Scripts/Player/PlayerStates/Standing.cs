using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Standing : PlayerBase
{
    private PlayerMovementSM sm;
    public Standing (PlayerMovementSM playerStateMachine) : base("Standing", playerStateMachine) {
        sm = (PlayerMovementSM)playerStateMachine;
    }
    
    public override void Enter()
    {
        base.Enter();   
    }

    public override void Update()
    {
        Debug.Log("On Standing state");
        base.Update();
       
        float playerDirectionX = sm.playerInput.actions["Movements"].ReadValue<Vector2>().x;
        float playerDirectionZ = sm.playerInput.actions["Movements"].ReadValue<Vector2>().y;
        
        if (playerDirectionX != 0f || playerDirectionZ != 0f)
        {                   
            playerStateMachine.ChangeState(sm.walkingState);
        }
    }

}
