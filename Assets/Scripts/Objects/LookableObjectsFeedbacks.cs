using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class LookableObjectsFeedbacks : MonoBehaviour
{
    [SerializeField] private AudioSource objectAudioSource;
    [SerializeField] private VisualEffect objectVFX;
    [SerializeField] public LookableObject lookableObject;
    void Start()
    {
        objectAudioSource.Stop();
        objectVFX.Stop();
    }

    private void PlayFeedbacks()
    {
        objectAudioSource.Play();
        objectVFX.Play();
        
    }

   

    // Update is called once per frame
    void Update()
    {
        if (lookableObject.GoFeedback == false)
        {
            PlayFeedbacks();
        }       
    }

    

}
