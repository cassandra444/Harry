using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPassiveState : PlayerBase
{
    public PlayerPassiveState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) 
    {
        InitializeSubState();
    }


    public override void EnterState() {
        //Ctx.PlayerAnimator.SetBool("Anim_PlayerInteracting", false);
    }
    public override void UpdateState() 
    {
        CheckSwitchState();
    }
    public override void ExitState() { }
    public override void InitializeSubState() 
    { 
        if(Ctx.PlayerIsMoving == true)
        {
            SetSubState(Factory.Walk());
        }else if (Ctx.PlayerIsMoving == false)
        {
            SetSubState(Factory.Idle());
        }
    }
    public override void CheckSwitchState() 
    {

      if (Ctx.PlayerInInteractingZone == true) 
        {
            SwitchState(Factory.Interact());
            
        }
    }
}
