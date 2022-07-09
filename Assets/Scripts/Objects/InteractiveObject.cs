using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class InteractiveObject : MonoBehaviour
{
    private bool playerInRange;
    private bool PlayerIsInteracting;

    [SerializeField] private Animator objectAnimator;
    [SerializeField] private AudioSource objectAudioSource;
    [SerializeField] private VisualEffect objectVFX;
    [SerializeField] private GameObject interactUI;
    [SerializeField] private GameObject backUI;

    private void Start()
    {
        playerInRange = false;
        PlayerIsInteracting = false;
        objectVFX.Stop();

        interactUI.SetActive(false);
        backUI.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

     void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {          
            playerInRange = false;
            PlayerIsInteracting = false;
        }
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
        if(playerInRange == true && PlayerIsInteracting == false)
        {
            interactUI.SetActive(true);
            backUI.SetActive(false);
        }else if (playerInRange == true && PlayerIsInteracting == true)
        {
            interactUI.SetActive(false);
            backUI.SetActive(true);
        }
        else
        {
            interactUI.SetActive(false);
            backUI.SetActive(false);
        }


        if(Input.GetKey(KeyCode.E) && playerInRange==true && PlayerIsInteracting == false)
        {
            PlayerIsInteracting = true;
            PlayObject();
        }
        else if(Input.GetKey(KeyCode.A) && playerInRange==true && PlayerIsInteracting==true)
        {
            StopObject();
            PlayerIsInteracting = false;
        }
       
    }
}
