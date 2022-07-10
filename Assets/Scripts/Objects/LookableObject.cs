
using UnityEngine;
using UnityEngine.VFX;

public class LookableObject : MonoBehaviour
{
    private bool playerInRange;
    private bool playerInteract;
    private bool mouseEnter;

    [SerializeField] private Animator objectAnimator;
    [SerializeField] private AudioSource objectAudioSource;
    [SerializeField] private VisualEffect objectVFX;
    [SerializeField] private Renderer objectRenderer;
    [SerializeField] private Transform cameraObjectSlot;
    [SerializeField] private GameObject lookableobject;
    [SerializeField] private Transform objectSlot;
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
        objectAudioSource.Play();
        objectVFX.Play();
        lookableobject.transform.position = new Vector3(cameraObjectSlot.position.x, cameraObjectSlot.position.y, cameraObjectSlot.position.z);
        objectRenderer.sharedMaterial = material[0];

    }

    private void StopObject ()
    {
        objectAnimator.SetBool("AnimateObject", false);
        objectAudioSource.Stop();
        objectVFX.Stop();

        lookableobject.transform.position = new Vector3(objectSlot.position.x, objectSlot.position.y, objectSlot.position.z);

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
