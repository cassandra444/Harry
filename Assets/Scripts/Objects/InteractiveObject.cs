
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using TMPro;

public class InteractiveObject : MonoBehaviour
{
    #region Variables
    private bool _playerInteract;
    private bool _mouseEnter;
    private bool _playerInInteractingZone;
    private Animator _objectAnimator;
    private AudioSource _objectAudioSource;
    //private VisualEffect _objectVisualEffect;
    private TextMeshProUGUI _dialogueText;

    [Header("References")]
    [SerializeField] private GameObject _object;   
    [SerializeField] public Animator _playerAnimator;
    [SerializeField] private PauseMenu _pauseMenu;

    [Header("Feedbacks")]
    [SerializeField] private float _interactionDuration = 3f;      
    public Texture2D _cursorTextureEnter;
    public Texture2D _cursorTextureExit;
    [HideInInspector] public CursorMode _cursorMode = CursorMode.Auto;
    [HideInInspector] public Vector2 _hotSpot = Vector2.zero;
    [SerializeField] private GameObject _outlinedObject;
    [SerializeField] private GameObject _dialogueCanvas;
    [SerializeField] private string _dialogue;
    #endregion

    private void Start()
    {
        _objectAnimator = GetComponent<Animator>();
        _objectAudioSource = GetComponent<AudioSource>();
        //_objectVisualEffect = GetComponentInChildren<VisualEffect>();
        _dialogueText = _dialogueCanvas.GetComponentInChildren<TextMeshProUGUI>();

        _outlinedObject.SetActive(false);
        _playerInteract = false;
        _dialogueText.text = "";
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
        if(_pauseMenu._mouseOnUi == false)
        {
            _outlinedObject.SetActive(true);
            _mouseEnter = true;
            Cursor.SetCursor(_cursorTextureEnter, _hotSpot, _cursorMode);
        }
       
    }

    private void OnMouseExit()
    {
        if (_pauseMenu._mouseOnUi == false) {
            _outlinedObject.SetActive(false);
            _mouseEnter = false;
            Cursor.SetCursor(_cursorTextureExit, _hotSpot, _cursorMode);
        }
        
    }
    #endregion

    #region Object Action
    private void PlayObject()
    {     
        _objectAnimator.SetBool("AnimateObject", true);
        _playerAnimator.SetBool("Anim_PlayerInteracting", true);
        StartCoroutine("PlayerTalk");
        StartCoroutine("PlayerStopInteract");
    }

    private void StopObject ()
    {
        _objectAnimator.SetBool("AnimateObject", false);
        _playerAnimator.SetBool("Anim_PlayerInteracting", false);
        _objectAudioSource.Play();
       // _objectVisualEffect.Play();

    }

    private IEnumerator PlayerStopInteract()
    {
        yield return new WaitForSeconds(_interactionDuration);
        _playerInteract = false;
        _dialogueText.text = "";
    }

    private IEnumerator PlayerTalk()
    {
        yield return new WaitForSeconds(_interactionDuration / 2f);
        _dialogueText.text = _dialogue;
    }
    #endregion

    void Update()
    {
        if (_mouseEnter == true && Input.GetMouseButton(0)) _playerInteract = true;

        if (_playerInteract == true && _playerInInteractingZone == true) PlayObject();
        else StopObject();      
    }
}
