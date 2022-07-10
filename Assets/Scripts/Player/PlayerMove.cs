using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Camera pcamera;

    private string groundTag = "Ground";
    private RaycastHit hit;

    private void Start()
    {
        //agent.speed = agentSpeed;
    }
    private void PlayerFollowsMouse()
    {
        Ray ray = pcamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag(groundTag))
            {
                agent.SetDestination(hit.point);               
            }
        }
    }

    public void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            PlayerFollowsMouse();
        }
    }
}
