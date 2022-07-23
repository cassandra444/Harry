using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.UI;

public class DoorManager : MonoBehaviour
{
    #region Variables
    private bool playerInteract;
    private bool mouseEnter;
    private bool _playerInInteractingZone;
    public bool _animatorBool;
    private Animator _objectAnimator;
    private AudioSource _objectAudioSource;

    [Header("References")]
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _object;
    [SerializeField] public Animator _playerAnimator;
    [SerializeField] private FindableObject _findableObject;
    [SerializeField] private GameObject _thanksCanvas;
    [SerializeField] private PauseMenu _pauseMenu;

    [Header("Feedbacks")]
    [SerializeField] private float _interactionDuration = 3f;
    [SerializeField] private GameObject _outlinedObject;
    public Texture2D _cursorTextureEnter;
    public Texture2D _cursorTextureExit;
    [HideInInspector] public CursorMode _cursorMode = CursorMode.Auto;
    [HideInInspector] public Vector2 _hotSpot = Vector2.zero;

    [Header("Quit BUtton")]
    public Image quitImage;
    public Sprite unselectQuitImage;
    public Sprite selectQuitImage;
    [SerializeField] private AudioSource _OnButtonSound;

    #endregion

    private void Start()
    {
        _objectAnimator = GetComponent<Animator>();
        _objectAudioSource = GetComponent<AudioSource>();

        _outlinedObject.SetActive(false);
        playerInteract = false;
        _thanksCanvas.SetActive(false);
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
        if(_pauseMenu._mouseOnUi == false) {
            _outlinedObject.SetActive(true);
            mouseEnter = true;
            Cursor.SetCursor(_cursorTextureEnter, _hotSpot, _cursorMode);
        }
        
    }

    private void OnMouseExit()
    {
        if(_pauseMenu._mouseOnUi == false) {
            _outlinedObject.SetActive(false);
            mouseEnter = false;
            Cursor.SetCursor(_cursorTextureExit, _hotSpot, _cursorMode);
        }
        
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
        _thanksCanvas.SetActive(true);
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

    public void ChangeQuit()
    {
        quitImage.sprite = selectQuitImage;
        _OnButtonSound.Play();
    }
    public void BackQuit()
    {
        quitImage.sprite = unselectQuitImage;
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
