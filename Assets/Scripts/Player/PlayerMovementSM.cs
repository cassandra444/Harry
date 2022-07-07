using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementSM : PlayerStateMachine
{
    [HideInInspector]public Standing standingState;
    [HideInInspector] public Walking walkingState;

    [SerializeField] public PlayerInput playerInput;
    [SerializeField] public CharacterController controller;
    [SerializeField] public Transform playerTransform;

    public void Awake()
    {
        standingState = new Standing(this);
        walkingState = new Walking(this);
      
    }

    protected override PlayerBase GetInitialState()
    {
        return standingState;
    }
}
