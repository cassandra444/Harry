using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;

    void Awake()
    {
        playerInput.actions["Interact"].performed += Interact;
    }

    public void Interact(InputAction.CallbackContext callback)
    {
        Debug.Log("Player is interacting");
    }
}
