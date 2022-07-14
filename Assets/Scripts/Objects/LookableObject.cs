
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.AI;

public class LookableObject : MonoBehaviour
{   
    private bool playerInteract;
    private bool mouseEnter;
    private bool objectPlayed;
    private float rotationSpeed = 4f;
    private bool _playerInInteractingZone;

    [Header("References")]
    [SerializeField] private NavMeshAgent playerAgent;
    [SerializeField] private GameObject cachePlane;
    [SerializeField] private Animator objectAnimator;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private Renderer objectRenderer;
    [SerializeField] private Transform cameraObjectSlot;
    [SerializeField] private Transform lookableobject;
    [SerializeField] private Transform objectSlot;

    [Header("Feedbacks")]
    [SerializeField] private float _interactionDuration = 3f;
    public Material[] material;
    [SerializeField] private AudioSource _objectAudioSource;
    [SerializeField] private VisualEffect _objectVisualEffect;

    private void Start()
    {
        objectRenderer.enabled = true;
        objectRenderer.sharedMaterial = material[0];
        cachePlane.SetActive(false);
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) _playerInInteractingZone = true;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) _playerInInteractingZone = false;
        
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
        objectAnimator.SetBool("AnimateObject", true);
        _playerAnimator.SetBool("Anim_PlayerInteracting", true);
        lookableobject.position = new Vector3(cameraObjectSlot.position.x, cameraObjectSlot.position.y, cameraObjectSlot.position.z);
        objectRenderer.sharedMaterial = material[0];
        objectPlayed = true;
        RotateOBject();
        playerAgent.speed = 0.01f;
        cachePlane.SetActive(true);
    }

    private void StopObject ()
    {
        objectAnimator.SetBool("AnimateObject", false);
        _playerAnimator.SetBool("Anim_PlayerInteracting", false);
        objectPlayed = false;
        playerInteract = false;
        lookableobject.position = new Vector3(objectSlot.position.x, objectSlot.position.y, objectSlot.position.z);
        playerAgent.speed = 1.5f;
        cachePlane.SetActive(false);
        StartCoroutine("PlayerStopInteract");
    }

    private IEnumerator PlayerStopInteract()
    {
        yield return new WaitForSeconds(_interactionDuration);
        playerInteract = false;
    }

    void Update()
    {
        if (mouseEnter == true && Input.GetMouseButton(0)) playerInteract = true;
       
       
       if (playerInteract == true && _playerInInteractingZone == true) PlayObject();
       else
        {
            _objectAudioSource.Play();
            _objectVisualEffect.Play();
        }

        if (playerInteract == true && _playerInInteractingZone == true && Input.GetMouseButton(1)) StopObject();
    }
}
