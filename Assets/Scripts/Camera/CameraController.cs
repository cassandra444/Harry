using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform Pos1;
    [SerializeField] private Transform Pos2;
    //[SerializeField] private Transform Pos3;

    private void Update()
    {
        transform.LookAt(target);
        //transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);

        //if (Input.GetKey(KeyCode.Keypad1)) transform.position = Pos1.transform.position;
        if (Input.GetKey(KeyCode.Keypad2)) transform.position = Pos2.transform.position;
        //if (Input.GetKey(KeyCode.Keypad3)) transform.position = Pos3.transform.position;
 
    }
}
