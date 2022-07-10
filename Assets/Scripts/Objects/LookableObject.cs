
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.AI;

public class LookableObject : MonoBehaviour
{   
    private bool playerInRange;
    private bool playerInteract;
    private bool mouseEnter;
    private bool objectPlayed;
    public bool GoFeedback;

    [SerializeField] private NavMeshAgent playerAgent;
    [SerializeField] private GameObject cachePlane;

    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private Animator objectAnimator;
    
    [SerializeField] private Renderer objectRenderer;
    [SerializeField] private Transform cameraObjectSlot;
    [SerializeField] private Transform lookableobject;
    [SerializeField] private Transform objectSlot;
    public Material[] material;

    private void Start()
    {
        objectRenderer.enabled = true;
        objectRenderer.sharedMaterial = material[0];
        cachePlane.SetActive(false);
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

     public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {          
            playerInRange = false;
        }
    }

    private void OnMouseEnter()
    {
        objectRenderer.sharedMaterial = material[1];
        mouseEnter = true;
    }

    private void OnMouseExit()
    {
        objectRenderer.sharedMaterial = material[0];
        mouseEnter = false;
    }

    void RotateOBject()
    {
        if (objectPlayed == true)
        {
            float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
            float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;

            lookableobject.Rotate(Vector3.down, XaxisRotation);
            lookableobject.Rotate(Vector3.right, YaxisRotation);
        }
    }

    private void PlayObject()
    {
        GoFeedback = true;
        objectAnimator.SetBool("AnimateObject", true);
        lookableobject.position = new Vector3(cameraObjectSlot.position.x, cameraObjectSlot.position.y, cameraObjectSlot.position.z);
        objectRenderer.sharedMaterial = material[0];
        objectPlayed = true;
        RotateOBject();
        playerAgent.speed = 0.01f;
        cachePlane.SetActive(true);

    }

    private void StopObject ()
    {
        GoFeedback = false;
        objectAnimator.SetBool("AnimateObject", false);
        objectPlayed = false;
        playerInteract = false;

        lookableobject.position = new Vector3(objectSlot.position.x, objectSlot.position.y, objectSlot.position.z);
        playerAgent.speed = 1.5f;
        cachePlane.SetActive(false);
    }
    

    void Update()
    {
        
        if (mouseEnter == true && Input.GetMouseButton(0))
        {
            playerInteract = true;
        }
       
       if (playerInteract == true && playerInRange == true)
        {
            PlayObject();
        }

        if (playerInteract == true && playerInRange == true && Input.GetMouseButton(1))
        {
           
            StopObject();      
        }
    }
}
