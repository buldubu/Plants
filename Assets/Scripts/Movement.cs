using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float hiz = 1;
    Vector2 input;
    public bool hasPlant;
    public Sprite PlantedDirt;
    public Animator animator;
    public float deneme = 0;
    public bool isDead = false;
    public WorldO2Bar progbar;
    public List<string> plantedDirtNames;
    private int currScene;
    private int targetScene;
    private bool sceneUpdated;


    void Start()
    {
        currScene = SceneManager.GetActiveScene().buildIndex;
        targetScene = SceneManager.GetActiveScene().buildIndex;
        sceneUpdated = false;

        //progbar.Increment(0.16f);
    }

    void Update()
    {
        if (currScene == targetScene && !sceneUpdated)
        {
            foreach (string plantedDirtName in plantedDirtNames)
            {
                Debug.Log(plantedDirtName);
                GameObject temp = GameObject.Find(plantedDirtName);
                temp.tag = "PlantedDirt";
                temp.GetComponent<SpriteRenderer>().sprite = PlantedDirt;
            }
            sceneUpdated = true;
        }
        else if (sceneUpdated)
        {
            currScene = SceneManager.GetActiveScene().buildIndex;
            if (currScene != targetScene)
            {
                sceneUpdated = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EmptyDirt" && hasPlant && !plantedDirtNames.Contains(collision.gameObject.name))
        {
            collision.gameObject.tag = "PlantedDirt";
            plantedDirtNames.Add(collision.gameObject.name);
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = PlantedDirt;
            hasPlant = false;
            progbar.Increment(0.16f);
        }
            
    }

    void FixedUpdate()
    {
        if (!isDead) { 
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
        if(Input.GetKeyDown(KeyCode.P))
            {
            PauseGame();
            }
        if(Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }

    }

    private void ResetGame()
    {
        Application.LoadLevel(Application.loadedLevel);

    }

    private void PauseGame()
    {
        if(Time.timeScale == 1f){Time.timeScale = 0f;}
        else{Time.timeScale = 1f;}
    }

}
