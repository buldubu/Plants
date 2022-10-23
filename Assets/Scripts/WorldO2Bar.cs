using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldO2Bar : MonoBehaviour
{
    private Slider slider;
    public float FillSpeed = 0.5f;
    private float Target = 0;

    private void Awake(){
        slider = gameObject.GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Increment(1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value < Target){
            slider.value += FillSpeed * Time.deltaTime;
        }
        if(slider.value == Target){
        Debug.Log("WON!!!!");
        GameWon();
    }
    }

    public void Increment(float newprog){
        Debug.Log("Increment");
        Target = slider.value + newprog;
    }
    private void GameWon(){
        
    }
}
