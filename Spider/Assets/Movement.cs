using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform body=default;
    float footSpacing1,footSpacing2;
    public float speed;
    Vector3 currentPosition;
    Vector3 newPostion,oldPostion;
    public float stepDistance,stepHeight;
    public Movement oppLeg1,oppLeg2,oppLeg3;
    private float lerp;
    public Vector3 offset;
    public LayerMask layermask;
    void Start()
    {
        footSpacing1 = transform.localPosition.x;
        footSpacing2 = transform.localPosition.z;
        currentPosition = newPostion = oldPostion = transform.position;
        lerp = 1;
    }

    void FixedUpdate()
    {   
        transform.position = currentPosition;
        Ray ray = new Ray(body.position + (body.right * footSpacing1)  + (body.forward * footSpacing2) + offset,Vector3.down);
        if(Physics.Raycast(ray,out RaycastHit hitInfo,5f,layermask))
        {
            if(Vector3.Distance(newPostion,hitInfo.point) > stepDistance && !oppLeg1.isMoving() && !oppLeg2.isMoving() && !oppLeg3.isMoving() && lerp>=1)
            {
                lerp = 0;
                newPostion= hitInfo.point;
                Debug.DrawRay(body.position + (body.right * footSpacing1) + (body.forward * footSpacing2),Vector3.down,Color.yellow,1f);
            }
        }
        if(lerp < 1)
        {
            Vector3 footPostion = Vector3.Slerp(oldPostion,newPostion,lerp);
            footPostion.y += Mathf.Sin(lerp * Mathf.PI) * stepHeight;
            currentPosition = footPostion;
            lerp += Time.fixedDeltaTime * speed;
        }
        else
        {
            oldPostion = newPostion;
            
        }
        
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(newPostion,0.06f);
    }

    private bool isMoving()
    {
        return lerp < 1;
    }
}
