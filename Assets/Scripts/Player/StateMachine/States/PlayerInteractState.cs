using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractState : PlayerBase
{
    
    public PlayerInteractState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) 
    {
        InitializeSubState();
        
    }

    public override void EnterState() 
    {
        PlayerInteract();
        
    }
    public override void UpdateState() 
    {
        CheckSwitchState();
    }
    public override void ExitState() { }
    public override void InitializeSubState() 
    {
        if (Ctx.PlayerIsMoving == true)
        {
            SetSubState(Factory.Walk());
        }
        else if (Ctx.PlayerIsMoving == false)
        {
            SetSubState(Factory.Idle());
        }
    }
    public override void CheckSwitchState() 
    {
        if (Ctx.PlayerInInteractingZone == false)
        {
            SwitchState(Factory.Passive());
        }
    }

    public void PlayerInteract()
    {
        //Debug.Log("Player is interacting");
        //Ctx.PlayerAnimator.SetBool("Anim_PlayerInteracting", true);
    }
}
