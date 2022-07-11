using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerStateMachine : MonoBehaviour
{
    
    [SerializeField] NavMeshAgent playerAgent;
    [SerializeField] Camera playerCamera;
    [SerializeField] Animator playerAnimator;

    public LayerMask layermask;
     RaycastHit hit;
     PlayerBase _currentState;
     PlayerStateFactory _states;
     bool _playerInInteractingZone;
     bool _playerIsMoving;

    //Animations
    int _velocityHash;
    public float _acceleration = 0.9f;
    public float _decceleration = 0.9f;
    public float _velocity = 0.0f;

    //getters and setters : access type variable type{get{"The current state"}set{"What the current state is"}}
    public PlayerBase CurrentState { get { return _currentState; }set { _currentState = value; } }
    public bool PlayerInInteractingZone { get { return _playerInInteractingZone; }set { _playerInInteractingZone = value; } }
    public bool PlayerIsMoving { get { return _playerIsMoving; } set { _playerIsMoving = value; } }
    public NavMeshAgent PlayerAgent { get { return playerAgent; } }
    public Camera PlayerCamera { get { return playerCamera; } }
    public Animator PlayerAnimator { get { return playerAnimator; } }
    public RaycastHit Hit { get { return hit; } }

    //Animations
    public int VelocityHash { get { return _velocityHash; } }
    public float Velocity { get { return _velocity; }set { _velocity = value; } }
    public float Acceleration { get { return _acceleration; } set { _acceleration = value; } }
    public float Deceleration { get { return _decceleration; } set { _decceleration = value; } }



    private void Awake()
    {
        _states = new PlayerStateFactory(this);
        _currentState = _states.Passive();
        _currentState.EnterState();
        _playerInInteractingZone = false;
        _playerIsMoving = false;
        _velocityHash = Animator.StringToHash("Anim_Velocity");
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
        _currentState.UpdateStates();

        //Animations
        if (_velocity < 0f)
            _velocity = 0f;
        if (_velocity > 1f)
            _velocity = 1f;

        if (playerAgent.velocity.magnitude > 0)
        {
            _velocity += Time.deltaTime * _acceleration;
        }

        if (playerAgent.velocity.magnitude <= 0.1f)
        {
            _velocity -= Time.deltaTime * _decceleration;
        }

        playerAnimator.SetFloat(_velocityHash, _velocity);


        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 3))
            {
                _playerIsMoving = true;              
            }
            else _playerIsMoving = false;
        }
        else _playerIsMoving = false;
      
    }

    
}
