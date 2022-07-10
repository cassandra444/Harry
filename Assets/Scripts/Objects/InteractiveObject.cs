
using UnityEngine;
using UnityEngine.VFX;

public class InteractiveObject : MonoBehaviour
{
    private bool playerInRange;
    private bool playerInteract;
    private bool mouseEnter;
    public bool GoFeedback;

    [SerializeField] private Animator objectAnimator;
    [SerializeField] private Renderer objectRenderer;

    public Material[] material;

    private void Start()
    {
        objectRenderer.enabled = true;
        objectRenderer.sharedMaterial = material[0];
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

     public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {          
            playerInRange = false;
        }
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

    

    private void PlayObject()
    {
        objectAnimator.SetBool("AnimateObject", true);
        GoFeedback = true;
    }

    private void StopObject ()
    {
        objectAnimator.SetBool("AnimateObject", false);
        GoFeedback = false;
    }


    

    void Update()
    {
        if (mouseEnter == true && Input.GetMouseButton(0))
        {
            playerInteract = true;
        }

        if (playerInteract == true && playerInRange == true)
        {
            PlayObject();
        }
        else StopObject();
    }
}
