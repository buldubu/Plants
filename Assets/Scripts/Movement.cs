using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float hiz = 1;
    Vector2 input;
    bool hasPlant;
    public Animator animator;
    

    void Start()
    {
        hasPlant = false;
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.Translate(new Vector3(input.x * Time.deltaTime * hiz, input.y * Time.deltaTime * hiz, 0));
        Vector3 theScale = transform.localScale;
        if (input.x > 0)
        {
            theScale.x = 1;
        }
        else if (input.x < 0)
        {
            theScale.x = -1;
        }
        transform.localScale = theScale;

        if (input.magnitude > 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

    }

}
