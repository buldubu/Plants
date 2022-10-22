using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player;
    // Start is called before the first frame update
    void Awake () {
        if(player == null) {
            player = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject); // or gameObject
        } 
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
