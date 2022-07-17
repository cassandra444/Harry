
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class InteractiveObject : MonoBehaviour
{
    #region Variables
    private bool _playerInteract;
    private bool _mouseEnter;
    private bool _playerInInteractingZone;
    private Animator _objectAnimator;
    private Renderer _objectRenderer;
    private AudioSource _objectAudioSource;
    private VisualEffect _objectVisualEffect;

    [Header("References")]
    [SerializeField] private GameObject _object;   
    [SerializeField] public Animator _playerAnimator;

    [Header("Feedbacks")]
    [SerializeField] private float _interactionDuration = 3f;      
    [SerializeField] public Material[] _materialsArray;
    #endregion

    private void Start()
    {
        _objectAnimator = GetComponent<Animator>();
        _objectAudioSource = GetComponent<AudioSource>();
        _objectRenderer = GetComponentInChildren<Renderer>();
        _objectVisualEffect = GetComponentInChildren<VisualEffect>();

        _objectRenderer.enabled = true;
        _objectRenderer.sharedMaterial = _materialsArray[0];
        _playerInteract = false;       
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
        _objectRenderer.sharedMaterial = _materialsArray[1];
        _mouseEnter = true;
    }

    private void OnMouseExit()
    {
        _objectRenderer.sharedMaterial = _materialsArray[0];
        _mouseEnter = false;
    }
    #endregion

    #region Object Action
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
        _playerInteract = false;
    }
    #endregion

    void Update()
    {
        if (_mouseEnter == true && Input.GetMouseButton(0)) _playerInteract = true;

        if (_playerInteract == true && _playerInInteractingZone == true) PlayObject();
        else StopObject();      
    }
}
