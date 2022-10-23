using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabCamFollow : MonoBehaviour
{
    public float xvalue_r;
    public float xvalue_l;
    private GameObject player;
    
    private Transform followTransform;
    private GameObject cameraObject;

    private void Start()
    {
        player = GameObject.Find("player");
        followTransform = player.transform;
        cameraObject = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(followTransform.position.x < xvalue_r && followTransform.position.x > xvalue_l){
            cameraObject.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);
        }
        else
        {
            cameraObject.transform.position = new Vector3(this.transform.position.x, followTransform.position.y, this.transform.position.z);
        }
    }
}