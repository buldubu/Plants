using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float xvalue_r;
    public float xvalue_l;
    
    public Transform followTransform;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if(followTransform.position.x < xvalue_r && followTransform.position.x > xvalue_l){
        this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);
        }
    }
}