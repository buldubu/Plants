using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    public float hiz = 1;
    Vector2 input;
    public bool hasPlant;
    public Animator animator;
    public float deneme = 0;


    void Start()
    {
        hasPlant = false;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EmptyDirt" && hasPlant)
        {
            var map = collision.collider.GetComponent<Tilemap>();
            var grid = map.layoutGrid;

            // Find the coordinates of the tile we hit.
            var contact = collision.GetContact(0);
            Vector3 contactPoint = contact.point - 0.05f * contact.normal;
            Vector3 gridPosition = grid.transform.InverseTransformPoint(contactPoint);
            Vector3Int cell = grid.LocalToCell(gridPosition);
            cell.z = 0;

            map.SetTile(cell, null);            
            hasPlant = false;
            
        }
            
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

        if (hasPlant)
        {
            animator.SetBool("hasPlant", true);
        }
        else
        {
            animator.SetBool("hasPlant", false);
        }

    }

}
