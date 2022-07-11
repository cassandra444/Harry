using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPassiveState : PlayerBase
{
    public PlayerPassiveState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) { }


    public override void EnterState() { }
    public override void UpdateState() {
        CheckSwitchState();
    }
    public override void ExitState() { }
    public override void InitializeSubState() { }
    public override void CheckSwitchState() {
        if (_ctx.PlayerInInteractingZone == true) 
        {
            SwitchState(_factory.Interact());
        }
    }
}
