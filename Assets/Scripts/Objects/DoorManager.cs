using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DoorManager : MonoBehaviour
{
    #region Variables
    private bool playerInteract;
    private bool mouseEnter;
    private bool _playerInInteractingZone;
    public bool _animatorBool;
    private Animator _objectAnimator;
    private Renderer _objectRenderer;
    private AudioSource _objectAudioSource;

    [Header("References")]
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _object;
    [SerializeField] public Animator _playerAnimator;
    [SerializeField] private FindableObject _findableObject;

    [Header("Feedbacks")]
    [SerializeField] private float _interactionDuration = 3f;
    public Material[] material;
    #endregion

    private void Start()
    {
        _objectAnimator = GetComponent<Animator>();
        _objectRenderer = GetComponentInChildren<Renderer>();
        _objectAudioSource = GetComponent<AudioSource>();

        _objectRenderer.enabled = true;
        _objectRenderer.sharedMaterial = material[0];
        playerInteract = false;
    }

    #region Checkers
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
    #endregion


    #region Object Action
    private void PlayCloseDoor()
    {      
        _playerAnimator.SetBool("Anim_PlayerInteracting", true);
        StartCoroutine("PlayerStopInteract");
    }

    private void PlayOpenDoor()
    {
        _objectAnimator.SetBool("AnimateObject", true);
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
    #endregion


    void Update()
    {      
        if (mouseEnter == true && Input.GetMouseButton(0)) playerInteract = true;

        if (playerInteract == true && _playerInInteractingZone == true && _findableObject._objectFinded == false) PlayCloseDoor();

        if(playerInteract == true && _playerInInteractingZone == true && _findableObject._objectFinded == true) PlayOpenDoor();
        else StopObject();
    }
}
