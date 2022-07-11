using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerStateMachine : MonoBehaviour
{
    // Add all states variable and OnMouseclic ...
     [SerializeField] NavMeshAgent playerAgent;
    [SerializeField] Camera playerCamera;
    [SerializeField] Animator playerAnimator;

     //string groundTag = "Ground";
     RaycastHit hit;
     PlayerBase _currentState;
     PlayerStateFactory _states;
     bool _playerInInteractingZone;

    //getters and setters : access type variable type{get{"The current state"}set{"What the current state is"}}
    public PlayerBase CurrentState { get { return _currentState; }set { _currentState = value; } }
    public bool PlayerInInteractingZone { get { return _playerInInteractingZone; }set { _playerInInteractingZone = value; } }
    public NavMeshAgent PlayerAgent { get { return playerAgent; } }
    public Camera PlayerCamera { get { return playerCamera; } }
    public Animator PlayerAnimator { get { return playerAnimator; } }
    public RaycastHit Hit { get { return hit; } }

    //public string GroundTag { get { return groundTag; } }

    private void Awake()
    {
        _states = new PlayerStateFactory(this);
        _currentState = _states.Passive();
        _currentState.EnterState();
        _playerInInteractingZone = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            _playerInInteractingZone = true;
        }
         
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            _playerInInteractingZone = false;
        }
    }


    void Update()
    {
        _currentState.UpdateState();                        
    }
}
