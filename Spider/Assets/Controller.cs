using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed=0.4f;
    public float turnSpeed =1f;
    public TrailRenderer bullet;
    public Transform shootingPoint;
    Vector2 input;
    float rotate;
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        rotate = Input.GetAxis("Mouse X");
        transform.position += new Vector3(input.x,0,input.y) * Time.deltaTime * speed;
        transform.Rotate(0,turnSpeed * rotate,0);
        if(Input.GetMouseButtonDown(0))
        {
          Shoot();
        }
           
    }

    void Shoot()
    {
        var tracer = Instantiate(bullet,shootingPoint.transform.position,Quaternion.identity);
        tracer.AddPosition(shootingPoint.transform.position);

        if(Physics.Raycast(shootingPoint.transform.position,Vector3.forward,out RaycastHit hitInfo,40))
        {
            if(hitInfo.point == null)
            {
                return;
            }
            else
            {
                tracer.transform.position = hitInfo.point;         
            }
        }
    }
}
