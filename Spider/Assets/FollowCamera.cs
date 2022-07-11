using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Vector3 offSet;
    
    void Update()
    {
        transform.position = player.transform.position + offSet;       
    }
}
