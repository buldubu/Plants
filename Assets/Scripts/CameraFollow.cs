using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float xvalue_r;
    public float xvalue_l;
    
    Transform followTransform;
    
    GameObject gameobject;
    //bool left = false;
    public GameObject player;
    void Start(){
        player = GameObject.Find("player");
        followTransform = player.transform;

        
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        player = GameObject.Find("player");
        followTransform = player.transform;
        gameobject = GameObject.Find("Main Camera");
        if(followTransform!=null){
            if(followTransform.position.x>xvalue_l && followTransform.position.x<xvalue_r){
                this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);
            }else if(followTransform.position.x <= xvalue_l){
                gameobject.transform.position = new Vector3(xvalue_l, followTransform.position.y, this.transform.position.z);
            }else{
                gameobject.transform.position = new Vector3(xvalue_r, followTransform.position.y, this.transform.position.z);
            }
        }
    }
}