using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private PlayerMovementSM sm;
    
    // try to turn private
    float velocityX = 0.0f;
    float velocityY = 0.0f;

    float globalVelocity = 0.0f;
    float maxGlobalVelocity = 1f;
    float minGlobalVelocity = 0f;


    public float acceleration = 0.2f;
    public float decceleration = 0.01f;
    int VelocityHash;
    

    void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        VelocityHash = Animator.StringToHash("Anim_Velocity");
    }

    private void Update()
    {
        
        velocityX = (sm.playerInput.actions["Movements"].ReadValue<Vector2>()).x;
        velocityY = (sm.playerInput.actions["Movements"].ReadValue<Vector2>()).y;
        Vector3 direction = new Vector3(velocityX, 0f, velocityY).normalized;

        if (globalVelocity < 0f)
            globalVelocity = 0f;
        if (globalVelocity > 1f)
            globalVelocity = 1f;

        if (velocityX == 1.0f || velocityX == -1.0f || velocityY == 1.0f || velocityY == -1.0f && direction != Vector3.zero)
        {

            globalVelocity = globalVelocity += 0.97f * Time.deltaTime;
           
        }

        if(velocityX == 0f && velocityY == 0f && direction == Vector3.zero)
        {
            globalVelocity = globalVelocity -= 0.95f * Time.deltaTime;
        }

        playerAnimator.SetFloat(VelocityHash, globalVelocity);
    }
}
