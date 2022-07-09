using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private NavMeshAgent agent;
    
    
    float velocity= 0.0f;
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
        if (velocity < 0f)
            velocity = 0f;
        if (velocity > 1f)
            velocity = 1f;

         if (agent.velocity. magnitude > 0)
         { 
            velocity += Time.deltaTime * acceleration;
         }

         if(agent.velocity.magnitude <= 0.1)
         {         
            velocity -= Time.deltaTime * decceleration;
        }

        playerAnimator.SetFloat(VelocityHash, velocity);
    }
}
