
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class InteractiveObject : MonoBehaviour
{

    private bool playerInteract;
    private bool mouseEnter;
    private bool _playerInInteractingZone;

    [Header("References")]
    [SerializeField] private Animator _objectAnimator;
    [SerializeField] private Renderer _objectRenderer;
    [SerializeField] private Animator _playerAnimator;

    [Header("Feedbacks")]
    [SerializeField] private float _interactionDuration = 3f;    
    [SerializeField] private AudioSource _objectAudioSource;
    [SerializeField] private VisualEffect _objectVisualEffect;
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

    private void PlayObject()
    {
        _objectAnimator.SetBool("AnimateObject", true);
        _playerAnimator.SetBool("Anim_PlayerInteracting", true);
        StartCoroutine("PlayerStopInteract");
    }

    private void StopObject ()
    {
        _objectAnimator.SetBool("AnimateObject", false);
        _playerAnimator.SetBool("Anim_PlayerInteracting", false);
        _objectAudioSource.Play();
        _objectVisualEffect.Play();
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
        else StopObject();      
    }
}
