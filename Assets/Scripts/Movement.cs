using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float hiz = 1;
    Vector2 input;
    void Start()
    {
    }

    void FixedUpdate()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.Translate(new Vector3(input.x * Time.deltaTime * hiz, input.y * Time.deltaTime * hiz, 0));

    }
}
