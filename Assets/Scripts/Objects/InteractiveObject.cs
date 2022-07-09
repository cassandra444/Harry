
using UnityEngine;
using UnityEngine.VFX;

public class InteractiveObject : MonoBehaviour
{
    private bool playerInRange;
    private bool playerInteract;
    private bool mouseEnter;

    [SerializeField] private Animator objectAnimator;
    [SerializeField] private AudioSource objectAudioSource;
    [SerializeField] private VisualEffect objectVFX;
    [SerializeField] private Renderer objectRenderer;


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
        objectRenderer.material.color = Color.red;
        mouseEnter = true;
    }

    private void OnMouseExit()
    {
        objectRenderer.material.color = Color.white;
        mouseEnter = false;
    }

    

    private void PlayObject()
    {
        objectAnimator.SetBool("AnimateObject", true);
        objectAudioSource.Play();
        objectVFX.Play();
        
    }

    private void StopObject ()
    {
        objectAnimator.SetBool("AnimateObject", false);
        objectAudioSource.Stop();
        objectVFX.Stop();
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
