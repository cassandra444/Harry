using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBase
{
    public PlayerIdleState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) { }

    public override void EnterState() 
    {
        DoIdle();
        
    }
    public override void UpdateState() 
    {
        CheckSwitchState();
    }
    public override void ExitState() { }
    public override void InitializeSubState() { }
    //public void UpdateStates() { }
    public override void CheckSwitchState() {
        if (Ctx.PlayerIsMoving == true )
        {
            SwitchState(Factory.Walk());
        }

        if (Ctx.PlayerInInteractingZone == true)
        {
            SwitchState(Factory.Interact());
        }
    }

    private void DoIdle()
    {
        

    }
}
