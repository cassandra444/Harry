
public class PlayerStateFactory 
{
    PlayerStateMachine _context;
   public PlayerStateFactory(PlayerStateMachine currentContext)
    {
        _context = currentContext;
    }

    public PlayerBase Idle()
    {
        return new PlayerIdleState(_context, this);
    }

    public PlayerBase Walk()
    {
        return new PlayerWalkState(_context, this);
    }

    public PlayerBase Passive()
    {
        return new PlayerPassiveState(_context, this);
    }

    public PlayerBase Interact()
    {
        return new PlayerInteractState(_context, this);
    }
}
