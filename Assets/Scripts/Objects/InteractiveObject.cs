using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField]  float interactSphereRadius = 1f;
   
    [SerializeField]  float lookSphereRadius = 1f;

    private void Start()
    {
       
    }

     void InteractZone()
    {
       if(Physics.CheckSphere(transform.position, interactSphereRadius, 3))
        {          
                Debug.Log("Player in Interact Zone ! ");
        }
    }

     void Update()
    {
        InteractZone();
    }

    void DrawCheckSphere()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, interactSphereRadius);
    }


}
