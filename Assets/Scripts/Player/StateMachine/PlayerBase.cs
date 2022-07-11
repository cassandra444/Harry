
public abstract class PlayerBase 
{
    protected PlayerStateMachine _ctx;
    protected PlayerStateFactory _factory;
    public PlayerBase(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    {
        _ctx = currentContext;
        _factory = playerStateFactory;
    }
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchState();
    public abstract void InitializeSubState();

    void UpdateStates() { }
    public void SwitchState(PlayerBase newState) {
        ExitState();
        newState.EnterState();
        _ctx.CurrentState = newState;
    }
    public void SetSuperState() { }
    public void SetSubState() { }
}
