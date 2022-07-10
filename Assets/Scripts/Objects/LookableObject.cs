
using UnityEngine;
using UnityEngine.VFX;

public class LookableObject : MonoBehaviour
{
    private bool playerInRange;
    private bool playerInteract;
    private bool mouseEnter;
    private bool objectPlayed;

    [SerializeField] private float rotationSpeed = 1f;

    [SerializeField] private Animator objectAnimator;
    [SerializeField] private AudioSource objectAudioSource;
    [SerializeField] private VisualEffect objectVFX;
    [SerializeField] private Renderer objectRenderer;
    [SerializeField] private Transform cameraObjectSlot;
    [SerializeField] private Transform lookableobject;
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
        objectAnimator.SetBool("AnimateObject", true);
        objectAudioSource.Play();
        objectVFX.Play();
        lookableobject.position = new Vector3(cameraObjectSlot.position.x, cameraObjectSlot.position.y, cameraObjectSlot.position.z);
        objectRenderer.sharedMaterial = material[0];
        objectPlayed = true;
        RotateOBject();
       

    }

    private void StopObject ()
    {
        objectAnimator.SetBool("AnimateObject", false);
        objectAudioSource.Stop();
        objectVFX.Stop();
        objectPlayed = false;

        lookableobject.position = new Vector3(objectSlot.position.x, objectSlot.position.y, objectSlot.position.z);

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
