
using UnityEngine;
using UnityEngine.VFX;

public class InteractiveObject : MonoBehaviour
{
    private bool playerInteract;
    private bool mouseEnter;

    [SerializeField] PlayerStateMachine _playerStateMachine;
    [SerializeField] private Animator _objectAnimator;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] public float _animTypeFloat = 0f;
    [SerializeField] private Renderer _objectRenderer;
    [SerializeField] private AudioSource _objectAudioSource;
    [SerializeField] private VisualEffect _objectVisualEffect;

    public Material[] material;

    private void Start()
    {
        _objectRenderer.enabled = true;
        _objectRenderer.sharedMaterial = material[0];
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
        _playerAnimator.SetFloat("Anim_Type", _animTypeFloat);


    }

    private void StopObject ()
    {
        _objectAnimator.SetBool("AnimateObject", false);
        _objectAudioSource.Play();
        _objectVisualEffect.Play();

    }

    void Update()
    {
        if (mouseEnter == true && Input.GetMouseButton(0))
        {
            playerInteract = true;
        }

        if (playerInteract == true && _playerStateMachine.PlayerInInteractingZone == true)
        {
            PlayObject();
           
        }
        else
        {
            StopObject();
        }

        
    }
}
