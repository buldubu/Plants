using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool game_is_paused = false;

    public GameObject pausemenu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(game_is_paused){
                Resume();
            }else{
                Pause();
            }
        }
    }

    public void Resume(){
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        game_is_paused = false;
    }

    void Pause(){
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        game_is_paused = true;
    }

    public void ReturnMainMenu(){
        GameObject p = GameObject.Find("player");
        Destroy(p);
        Time.timeScale = 1f;
        game_is_paused = false;
        SceneManager.LoadScene("Start");
    }

    public void Quit(){
        Application.Quit();
    }
}
