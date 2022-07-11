using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour
{
    public Transform[] leg;
    public Transform rayOrigin;
    public float smooth =1;
    public float bodyRotationSpeed;
    public LayerMask layerMask;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        //Ray ray = new Ray(rayOrigin.transform.position,Vector3.down);
        //Physics.Raycast(ray,out RaycastHit hitInfo,10,layerMask);

        Vector3 v1 = Vector3.Cross(leg[1].transform.position - leg[0].transform.position,leg[3].transform.position - leg[2].transform.position).normalized;
        //float singleStep = bodyRotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.right,v1,Mathf.PI,0.0f);
        Debug.DrawRay(transform.position, newDirection, Color.red);
        transform.rotation = Quaternion.LookRotation(newDirection);

    }   
}
