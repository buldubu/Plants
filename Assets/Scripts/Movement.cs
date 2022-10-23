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
    

    private int targetScene;
    public AudioSource audiosrc;
    public AudioSource audiosrc2;

    private GameObject flowerGame = null;


    void Start()
    {

        //progbar.Increment(0.16f);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "House")
        {
            foreach (string plantedDirtName in plantedDirtNames)
            {
                GameObject temp = GameObject.Find(plantedDirtName);
                if (temp.tag == "EmptyDirt")
                {
                    temp.tag = "PlantedDirt";
                    temp.GetComponent<SpriteRenderer>().sprite = PlantedDirt;
                }
            }
        }else if(flowerGame == null && SceneManager.GetActiveScene().name == "Lab")
        {
            flowerGame = GameObject.Find("FlowerGame");
            flowerGame.SetActive(false);
        }
        if(animator.GetBool("isMoving") ){
             //SoundManagerScript.PlaySound("glassbreak");
            if(!audiosrc.isPlaying){
                SoundManagerScript.PlaySound("sandwalk");
            }
        }
       /* if (SceneManager.GetActiveScene().name == "Company"){
            //audiosrc2.mute = true;
            //audiosrc.mute = false;
            SoundManagerScript.PlaySound("lament_hisli");
        }
        if (SceneManager.GetActiveScene().name == "Company2"){
            //audiosrc2.mute = true;
            SoundManagerScript.PlaySound("lament_hisli");
        }
        if (SceneManager.GetActiveScene().name == "House"){
            //audiosrc.mute = true;
            //audiosrc2.mute = false;
            SoundManagerScript.PlaySound("lament");
        }
        if (SceneManager.GetActiveScene().name == "Desert"){
            //audiosrc.mute=true;
            //audiosrc2.mute = false;
            SoundManagerScript.PlaySound("lament");
        }
        if (SceneManager.GetActiveScene().name == "Lab"){
            //audiosrc.mute = false;
            //SoundManagerScript.PlaySound("lament");
        }*/        
        if (SceneManager.GetActiveScene().name == "Start"){
            //audiosrc.mute = false;
            SoundManagerScript.PlaySound("lament");
        }             
        if (Input.GetKeyDown(KeyCode.H))
        {
            hasPlant = !hasPlant;
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
        }else if(collision.gameObject.tag == "FlowerGame")
        {
            flowerGame.SetActive(true);
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
        else if(isDead){
            audiosrc2.mute = false;
            SoundManagerScript.PlaySound("lament_hisli");
        }

    }


}
