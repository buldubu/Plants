using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float xvalue_r;
    public float xvalue_l;
    
    Transform followTransform;
    GameObject cameraObject;

    public GameObject player;
    void Start(){
        player = GameObject.Find("player");
        followTransform = player.transform;
        cameraObject = GameObject.Find("Main Camera");
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if(followTransform!=null){
            if(followTransform.position.x>xvalue_l && followTransform.position.x<xvalue_r){
                cameraObject.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);
            }else if(followTransform.position.x <= xvalue_l){
                cameraObject.transform.position = new Vector3(xvalue_l, followTransform.position.y, this.transform.position.z);
            }else{
                cameraObject.transform.position = new Vector3(xvalue_r, followTransform.position.y, this.transform.position.z);
            }
        }
    }
}