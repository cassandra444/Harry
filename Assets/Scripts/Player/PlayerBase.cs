using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase 
{  
    public string name;
    protected PlayerStateMachine playerStateMachine;

    public PlayerBase(string name, PlayerStateMachine playerStateMachine)
    {
        this.name = name;
        this.playerStateMachine = playerStateMachine;
    }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}
