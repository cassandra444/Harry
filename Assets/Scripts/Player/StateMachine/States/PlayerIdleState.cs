using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBase
{
    public PlayerIdleState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) { }
public override void EnterState() { }
    public override void UpdateState() {
        CheckSwitchState();
    }
    public override void ExitState() { }
    public override void InitializeSubState() { }
    public override void CheckSwitchState() { }
}
