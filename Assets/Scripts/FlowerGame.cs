using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerGame : MonoBehaviour
{
    // move the cursor
    public Transform firstBound;
    public Transform secondBound;
    public Transform thirdBound;
    public Transform fourthBound;
    public Transform fifthBound;
    public Transform sixthBound;

    public GameObject perfIndicator;
    public GameObject aweIndicator;
    public GameObject failIndicator;
    private bool isClicked = false;
    
    [Header("Cursor Areas")]
    public GameObject myCursor;
    [SerializeField] float curTimeRandomizer = 3f;
    [SerializeField] float cursorSize = 0.08f;

    float curPosition;
    float curSpeed;
    float curTimer;
    float curTargetPosition;
    bool win = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update(){
        
        if(isClicked == false){
            checkMoves();
        }
    }       

    private void FixedUpdate(){
        if(isClicked == false){
            moveCursor();
        }
    }

    // top of bar  = 1 , bottom = 0 for maths
    private void moveCursor(){
        // based on timer, pick rand position 
        // move cursor to that pos smoothly
        curTimer -= Time.deltaTime;
        if(curTimer < 0) {
            // pick new target random pos, reset timer
            curTimer = Random.value * curTimeRandomizer;
        }
        // PingPong returns a value that will increment and decrement between the value 0 and length.
        myCursor.transform.position = new Vector3(myCursor.transform.position.x, sixthBound.position.y + cursorSize + ( (1-Mathf.PingPong(Time.time , 1)) * (firstBound.position.y - sixthBound.position.y - cursorSize)), myCursor.transform.position.z);
    }

    private void checkMoves(){
        if(Input.GetMouseButtonDown(0)) {
            isClicked = true;
            cutFlower();
        }
    }
    
    private void cutFlower(){
        float posY = myCursor.transform.position.y;
        cursorSize = 0;
        if((posY < firstBound.position.y - cursorSize && posY > secondBound.position.y + cursorSize) || 
            (posY < fifthBound.position.y + cursorSize && posY > sixthBound.position.y)) {
            // fail 1-2, 5-6
            failIndicator.GetComponent<SpriteRenderer>().enabled = true;
            win = false;
        } else if((posY + cursorSize < secondBound.position.y  && posY > thirdBound.position.y + cursorSize) || 
                    (posY + cursorSize < fourthBound.position.y && posY > fifthBound.position.y + cursorSize) ){
            // ave 2-3, 4-5            
            aweIndicator.GetComponent<SpriteRenderer>().enabled = true;
            win = true;
        } else if(posY + cursorSize < thirdBound.position.y && posY > fourthBound.position.y + cursorSize){
            // 3-4 WIN
            perfIndicator.GetComponent<SpriteRenderer>().enabled = true;
            win = true;
        }

        myCursor.transform.position = new Vector3(myCursor.transform.position.x, myCursor.transform.position.y, myCursor.transform.position.z);
        Invoke("finishGame", 2.5f);
    }

    private void finishGame()
    {
        GameObject player = GameObject.Find("player");
        player.GetComponent<Movement>().hasPlant = win;
        GameObject flowerGame = GameObject.Find("FlowerGame");
        flowerGame.SetActive(false);
    }
}
