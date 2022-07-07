using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Walking: PlayerBase
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float turnSmoothVelocity;

    private PlayerMovementSM sm;
    private float playerDirectionX;
    private float playerDirectionZ;
    private CharacterController controller;
    private Transform playerTransform;

    public Walking (PlayerMovementSM playerStateMachine) : base("Standing", playerStateMachine) {
        sm = (PlayerMovementSM)playerStateMachine;
        controller = sm.controller;
        playerTransform = sm.playerTransform;
    }

    public override void Enter()
    {
        Debug.Log("On Walking State");
        base.Enter();       
    }

    public override void Update()
    {
        base.Update();
        playerDirectionX = (sm.playerInput.actions["Movements"].ReadValue<Vector2>()).x;
        playerDirectionZ = (sm.playerInput.actions["Movements"].ReadValue<Vector2>()).y;
        Vector3 direction = new Vector3(playerDirectionX, 0f, playerDirectionZ).normalized;
        

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(playerTransform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            playerTransform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(direction * speed * Time.deltaTime);
        }

        if (playerDirectionX ==0f && playerDirectionZ ==0f)
        {
            playerStateMachine.ChangeState(sm.standingState);
        }        
    }

}
