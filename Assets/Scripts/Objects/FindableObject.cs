using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.AI;

public class FindableObject : MonoBehaviour
{
    #region Variables
    private bool playerInteract;
    private bool mouseEnter;
    private bool objectPlayed;
    private float rotationSpeed = 4f;
    private bool _playerInInteractingZone;
    [HideInInspector] public bool _objectFinded;
    private NavMeshAgent _playerAgent;
    private Renderer _objectRenderer;
    private Transform _objectSlot;
    private AudioSource _objectAudioSource;
    private VisualEffect _objectVisualEffect;

    [Header("References")]
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _object;
    [SerializeField] private GameObject _cachePlane;
    [SerializeField] private GameObject _congratText;
    [SerializeField] private GameObject _harryShoes;
    [SerializeField] public Animator _playerAnimator;
    [SerializeField] private Transform _cameraObjectSlot;
    [SerializeField] private Transform _lookableobject;

    [Header("Feedbacks")]
    [SerializeField] private float _interactionDuration = 3f;
    public Material[] _materialArray;
    #endregion

    private void Start()
    {
        _playerAgent = _player.GetComponent<NavMeshAgent>();
        _objectRenderer = GetComponentInChildren<Renderer>();
        _objectSlot = _object.transform;
        _objectAudioSource = GetComponent<AudioSource>();
        _objectVisualEffect = GetComponentInChildren<VisualEffect>();

        _objectFinded = false;
        _objectRenderer.enabled = true;
        _objectRenderer.sharedMaterial = _materialArray[0];
        _cachePlane.SetActive(false);
        _congratText.SetActive(false);
        _harryShoes.SetActive(false);
    }

    #region Checker
    private void OnMouseEnter()
    {
        _objectRenderer.sharedMaterial = _materialArray[1];
        mouseEnter = true;
    }

    private void OnMouseExit()
    {
        _objectRenderer.sharedMaterial = _materialArray[0];
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
        _playerAnimator.SetBool("Anim_PlayerLook", true);
        _lookableobject.position = new Vector3(_cameraObjectSlot.position.x, _cameraObjectSlot.position.y, _cameraObjectSlot.position.z);
        _objectRenderer.sharedMaterial = _materialArray[0];
        objectPlayed = true;
        RotateOBject();
        _playerAgent.speed = 0.01f;
        _cachePlane.SetActive(true);
        _congratText.SetActive(true);
    }

    private void StopObject()
    {
        _objectFinded = true;
        _playerAnimator.SetBool("Anim_PlayerLook", false);
        objectPlayed = false;
        playerInteract = false;
        _lookableobject.position = new Vector3(_objectSlot.position.x, _objectSlot.position.y, _objectSlot.position.z);
        _lookableobject.rotation = _objectSlot.rotation;
        _objectSlot.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        _playerAgent.speed = 1.5f;
        _cachePlane.SetActive(false);
        _congratText.SetActive(false);
        StartCoroutine("PlayerStopInteract");
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

        if (playerInteract == true && _playerInInteractingZone == true) PlayObject();
        else
        {
            _objectAudioSource.Play();
            _objectVisualEffect.Play();
        }

        if (playerInteract == true && _playerInInteractingZone == true && Input.GetMouseButton(1)) StopObject();

        if (_objectFinded == true) _harryShoes.SetActive(true);
    }
}