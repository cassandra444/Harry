
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.AI;

public class LookableObject : MonoBehaviour
{
    #region Variables
    private bool playerInteract;
    private bool mouseEnter;
    private bool objectPlayed;
    private float rotationSpeed = 4f;
    private bool _playerInInteractingZone;
    private NavMeshAgent _playerAgent;
    private Animator _objectAnimator; 
    private Transform _objectSlot;
    private AudioSource _objectAudioSource;
    private VisualEffect _objectVisualEffect;

    [Header("References")]
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _object;
    [SerializeField] private GameObject _cachePlane;
    [SerializeField] public Animator _playerAnimator;  
    [SerializeField] private Transform _cameraObjectSlot;
    [SerializeField] private Transform _lookableobject;
    [SerializeField] private PauseMenu _pauseMenu;


    [Header("Feedbacks")]
    [SerializeField] private float _interactionDuration = 3f;
    [SerializeField] private GameObject _outlinedObject;
    public Texture2D _cursorTextureEnter;
    public Texture2D _cursorTextureExit;
    [HideInInspector] public CursorMode _cursorMode = CursorMode.Auto;
    [HideInInspector] public Vector2 _hotSpot = Vector2.zero;
    [SerializeField] private GameObject _LookableUI;
    #endregion

    private void Start()
    {
        _playerAgent = _player.GetComponent<NavMeshAgent>();
        _objectAnimator = GetComponent<Animator>();
        _objectSlot = _object.transform;
        _objectAudioSource = GetComponent<AudioSource>();
        _objectVisualEffect = GetComponentInChildren<VisualEffect>();

        _outlinedObject.SetActive(false);
        _cachePlane.SetActive(false);
        _LookableUI.SetActive(false);
    }

    #region Checker
    public void OnMouseEnter()
    {
        if(_pauseMenu._mouseOnUi == false && objectPlayed == false) {
            _outlinedObject.SetActive(true);
            mouseEnter = true;
            Cursor.SetCursor(_cursorTextureEnter, _hotSpot, _cursorMode);
        }
        
    }

    private void OnMouseExit()
    {
        if (_pauseMenu._mouseOnUi == false && objectPlayed == false) {
            _outlinedObject.SetActive(false);
            mouseEnter = false;
            Cursor.SetCursor(_cursorTextureExit, _hotSpot, _cursorMode);
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) _playerInInteractingZone = true;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) _playerInInteractingZone = false;
        
    }
    #endregion

    #region Object Action
    void RotateOBject()
    {
        if (objectPlayed == true)
        {
            float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
            float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;
            _lookableobject.Rotate(Vector3.down, XaxisRotation);
            _lookableobject.Rotate(Vector3.right, YaxisRotation);
        }
    }

    private void PlayObject()
    {
        _objectAnimator.SetBool("AnimateObject", true);
        _playerAnimator.SetBool("Anim_PlayerLook", true);
        _lookableobject.position = new Vector3(_cameraObjectSlot.position.x, _cameraObjectSlot.position.y, _cameraObjectSlot.position.z);
        objectPlayed = true;
        RotateOBject();
        _playerAgent.speed = 0.01f;
        _cachePlane.SetActive(true);
        _LookableUI.SetActive(true);
        StartCoroutine("PlayerTalk");
    }

    private void StopObject ()
    {
        _objectAnimator.SetBool("AnimateObject", false);
        _playerAnimator.SetBool("Anim_PlayerLook", false);
        objectPlayed = false;
        playerInteract = false;
        _lookableobject.position = new Vector3(_objectSlot.position.x, _objectSlot.position.y, _objectSlot.position.z);
        _lookableobject.rotation = _objectSlot.rotation;
        _playerAgent.speed = 1.5f;
        _cachePlane.SetActive(false);
        _LookableUI.SetActive(false);
        StartCoroutine("PlayerStopInteract");
        
    }

   

    private IEnumerator PlayerStopInteract()
    {
        yield return new WaitForSeconds(_interactionDuration);
        playerInteract = false;
    }

    private IEnumerator PlayerTalk()
    {
        yield return new WaitForSeconds(_interactionDuration / 2f);
        Debug.Log("player talk");
    }
    #endregion

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
