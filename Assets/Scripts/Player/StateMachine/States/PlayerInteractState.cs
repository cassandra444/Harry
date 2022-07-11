using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractState : PlayerBase
{
    public PlayerInteractState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) { }
public override void EnterState() {
        PlayerInteract();
    }
    public override void UpdateState() {
        CheckSwitchState();
    }
    public override void ExitState() { }
    public override void InitializeSubState() { }
    public override void CheckSwitchState() {
        if (_ctx.PlayerInInteractingZone == false)
        {
            SwitchState(_factory.Passive());
        }
    }

    public void PlayerInteract()
    {
        Debug.Log("Player is interacting");
    }
}
