using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBase
{
    public PlayerWalkState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) 
    : base(currentContext, playerStateFactory){}

    public override void EnterState() 
    {
        PlayerFollowsMouse();
        //Ctx.WalkStepSound.SetActive(true);
    }
    public override void UpdateState() 
    {
        CheckSwitchState();
    }
    public override void ExitState() {
    }
    public override void InitializeSubState() { } 
    public override void CheckSwitchState() 
    {
        if(Ctx.PlayerIsMoving == false )
        {
            SwitchState(Factory.Idle());
            //Ctx.WalkStepSound.SetActive(false);

        }

        if (Ctx.PlayerInInteractingZone == true)
        {
            SwitchState(Factory.Interact());
        }
    }

    private void PlayerFollowsMouse()
    {
        Ctx.PlayerAgent.SetDestination(Ctx.Hit.point);
        //Ctx.WalkStepSound.SetActive(true);
    }


}
