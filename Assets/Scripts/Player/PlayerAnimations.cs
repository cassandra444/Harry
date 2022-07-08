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
    //public float acceleration = 0.001f;
    //public float decceleration = 0.5f;
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
       
      

        if (velocityX == 1.0f || velocityX == -1.0f || velocityY == 1.0f || velocityY == -1.0f && direction != Vector3.zero)
        {
            //globalVelocity = 1;

            globalVelocity = Mathf.Lerp(globalVelocity, 1, 0.5f);
           
        }

        if(velocityX == 0f && velocityY == 0f && direction == Vector3.zero)
        {
            globalVelocity = Mathf.Lerp(globalVelocity, 0, 0.5f);
        }

        playerAnimator.SetFloat(VelocityHash, globalVelocity);

        Debug.Log(globalVelocity);
       
    }
}
