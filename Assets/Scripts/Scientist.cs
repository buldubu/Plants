using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scientist : MonoBehaviour {
    private Vector3 directionVector;
    private Transform myTransform;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Animator anim;
    public Collider2D bounds;
    public bool isMoving = true;
    public bool isCatched = false;
    public float minMoveTime;
    public float maxMoveTime;
    private float moveTimeSeconds;
    public float minWaitTime;
    public float maxWaitTime;
    private float waitTimeSeconds;
    private Animator player_anim;
    public bool finish = false;
    private GameObject canvas;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        canvas.SetActive(false);
        player_anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
        moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
        waitTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
        anim = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        directionVector = Vector3.left;
        ChangeDirection();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isMoving = false;
            isCatched = true;
            anim.SetBool("isCatched", true);
            player_anim.SetBool("isDead", true);
            Gameover();
        }
    }

    void FixedUpdate ()
    {
        if(isMoving && !finish)
        {
            Move();
        }
        else if(!isCatched)
        {
            waitTimeSeconds -= Time.deltaTime;
            if(waitTimeSeconds <= 0)
            {
                ChooseDifferentDirection();
                isMoving = true;
                waitTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
            }
            anim.SetBool("isMoving", false);
        }else
        {
            anim.SetBool("isMoving", false);
        }
    }


    private void Gameover()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Scientist>().finish = true;
        }
        Invoke("killPlayer", 0.3f);
        Debug.Log("GAMEOVER");
    }

    private void killPlayer()
    {
        canvas.SetActive(true);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Movement>().isDead = true;
    }

    private void Move()
    {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        if (bounds.bounds.Contains(temp))
        {
            myRigidbody.MovePosition(temp);
        }
        else
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        int direction = Random.Range(0, 4); //?????
        Vector3 theScale = transform.localScale;
        switch(direction)
        {   
            case 0:
                // Walking to the right
                theScale.x = -1;
                directionVector = Vector3.right;
                break;
            case 1:
                // Walking up
                directionVector = Vector3.up;
                break;
            case 2:
                // Walking Left
                theScale.x = 1;
                directionVector = Vector3.left;
                break;
            case 3:
                // Walking down
                directionVector = Vector3.down;
                break;
            default:
                break;
        }
        transform.localScale = theScale;
        anim.SetBool("isMoving", true);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        ChooseDifferentDirection();
    }

    private void ChooseDifferentDirection()
    {
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0;
        while (temp == directionVector && loops < 100)
        {
            loops++;
            ChangeDirection();
        }
    }
}
