using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
   
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private CharacterController controller;

    [SerializeField] private float speed = 6f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float turnSmoothVelocity;

    void Awake()
    {
        playerInput.actions["Interact"].performed += Interact;
        playerInput.actions["Movements"].performed += Move ;

    }

    public void Interact(InputAction.CallbackContext callback)
    {
        Debug.Log("Player is interacting");
    }

    public void Move(InputAction.CallbackContext callback)
    {
        Debug.Log(playerInput.actions["Movements"].ReadValueAsObject());
          
    }
    void Update()
    {
    
       /*float horizontal = Input.GetAxisRaw("Horizontal");
       float vertical = Input.GetAxisRaw("Vertical");
       float horizontal = InputAction.
       Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * speed * Time.deltaTime);
        }*/
    }
}
