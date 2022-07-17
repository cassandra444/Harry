using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DoorManager : MonoBehaviour
{
    private bool playerInteract;
    private bool mouseEnter;
    private bool _playerInInteractingZone;
    public bool _animatorBool;

    [Header("References")]
    [SerializeField] private Animator _objectAnimator;
    [SerializeField] private Renderer _objectRenderer;
    [SerializeField] public Animator _playerAnimator;
    [SerializeField] private FindableObject _findableObject;

    [Header("Feedbacks")]
    [SerializeField] private float _interactionDuration = 3f;
    [SerializeField] private AudioSource _objectAudioSource;
    public Material[] material;

    private void Start()
    {
        _objectRenderer.enabled = true;
        _objectRenderer.sharedMaterial = material[0];
        playerInteract = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) _playerInInteractingZone = true;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) _playerInInteractingZone = false;
    }

    private void OnMouseEnter()
    {
        _objectRenderer.sharedMaterial = material[1];
        mouseEnter = true;
    }

    private void OnMouseExit()
    {
        _objectRenderer.sharedMaterial = material[0];
        mouseEnter = false;
    }

    private void PlayCloseDoor()
    {      
       // _playerAnimator.SetBool("Anim_PlayerInteracting", true);
        StartCoroutine("PlayerStopInteract");
    }

    private void PlayOpenDoor()
    {
        Debug.Log("player in with shoes ! ");
        _objectAnimator.SetBool("AnimateObject", true);
        _playerAnimator.SetBool("Anim_PlayerInteracting", true);
        StartCoroutine("PlayerStopInteract");
        _objectAudioSource.Play();
    }

    private void StopObject()
    {
        _objectAnimator.SetBool("AnimateObject", false);
        _playerAnimator.SetBool("Anim_PlayerInteracting", false);
    }

    private IEnumerator PlayerStopInteract()
    {
        yield return new WaitForSeconds(_interactionDuration);
        playerInteract = false;
    }

    void Update()
    {
        Debug.Log("PLayer found object :" + _findableObject._objectFinded);
        if (Input.GetKeyDown(KeyCode.E))
        {
            _objectAnimator.SetBool("AnimateObject", true);
        }
        if (mouseEnter == true && Input.GetMouseButton(0))
        {
            playerInteract = true;
        }

        if (playerInteract == true && _playerInInteractingZone == true && _findableObject._objectFinded == false)
        {
            PlayCloseDoor();
        }
        if(playerInteract == true && _playerInInteractingZone == true && _findableObject._objectFinded == true)
        {
            PlayOpenDoor();
        }
        else StopObject();
    }
}
