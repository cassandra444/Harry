using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.AI;

public class FindableObject : MonoBehaviour
{
    private bool playerInteract;
    private bool mouseEnter;
    private bool objectPlayed;
    private float rotationSpeed = 4f;
    private bool _playerInInteractingZone;

    [HideInInspector] public bool _objectFinded;

    [Header("References")]
    [SerializeField] private UnityEngine.AI.NavMeshAgent playerAgent;
    [SerializeField] private GameObject cachePlane;
    [SerializeField] private GameObject congratText;
    [SerializeField] private GameObject harryShoes;

    [SerializeField] public Animator _playerAnimator;
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
        _objectFinded = false;
        objectRenderer.enabled = true;
        objectRenderer.sharedMaterial = material[0];
        cachePlane.SetActive(false);
        congratText.SetActive(false);
        harryShoes.SetActive(false);
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
        _playerAnimator.SetBool("Anim_PlayerLook", true);
        lookableobject.position = new Vector3(cameraObjectSlot.position.x, cameraObjectSlot.position.y, cameraObjectSlot.position.z);
        objectRenderer.sharedMaterial = material[0];
        objectPlayed = true;
        RotateOBject();
        playerAgent.speed = 0.01f;
        cachePlane.SetActive(true);
        congratText.SetActive(true);
    }

    private void StopObject()
    {
        _objectFinded = true;
        _playerAnimator.SetBool("Anim_PlayerLook", false);
        objectPlayed = false;
        playerInteract = false;
        lookableobject.position = new Vector3(objectSlot.position.x, objectSlot.position.y, objectSlot.position.z);
        lookableobject.rotation = objectSlot.rotation;
        objectSlot.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        playerAgent.speed = 1.5f;
        cachePlane.SetActive(false);
        congratText.SetActive(false);
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

        if (playerInteract == true && _playerInInteractingZone == true)
        {
            PlayObject();
        }
        else
        {
            _objectAudioSource.Play();
            _objectVisualEffect.Play();
        }

        if (playerInteract == true && _playerInInteractingZone == true && Input.GetMouseButton(1)) StopObject();
        if (_objectFinded == true) harryShoes.SetActive(true);
    }
}
