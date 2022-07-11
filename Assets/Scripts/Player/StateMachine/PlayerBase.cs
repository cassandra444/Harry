
public abstract class PlayerBase 
{
    private PlayerStateMachine _ctx;
    private PlayerStateFactory _factory;
    private PlayerBase _currentSubState;
    private PlayerBase _currentSuperState;

    protected PlayerStateMachine Ctx { get { return _ctx; } }
    protected PlayerStateFactory Factory { get { return _factory; } }

    public PlayerBase( PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
    {
        _ctx = currentContext;
        _factory = playerStateFactory;
    }
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchState();
    public abstract void InitializeSubState();

    public void UpdateStates() {
        UpdateState();
        if(_currentSubState != null)
        {
            _currentSubState.UpdateStates();
        }
    }
    public void SwitchState(PlayerBase newState) {
        ExitState();
        newState.EnterState();
        _ctx.CurrentState = newState;
    }
    public void SetSuperState(PlayerBase newSuperState) {
        _currentSuperState = newSuperState;
    }
    public void SetSubState(PlayerBase newSubState) {
        _currentSubState = newSubState;
    }
}
