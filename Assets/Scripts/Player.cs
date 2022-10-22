using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public GameObject spawn;
    public GameObject spawn_2;
    Vector3 spawn_point;
    Vector3 spawn_point_2;
    public static Player player;

    int scene_prev;
    int scene_current;
    bool change_1 = false;
    bool change_2 = false;
    // Start is called before the first frame update
    void Awake()
    {
        if (player == null)
        {
            player = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // or gameObject
        }
    }

    void Start()
    {
        scene_prev = SceneManager.GetActiveScene().buildIndex;
        scene_current = scene_prev;
        spawn = GameObject.Find("spawn");
        spawn_point = spawn.transform.position;
        this.transform.position = new Vector3(spawn_point.x, spawn_point.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        scene_current = SceneManager.GetActiveScene().buildIndex;
        if (scene_prev < scene_current)
        {
            change_1 = true;
            scene_prev = scene_current;
        }
        else if (scene_prev > scene_current)
        {
            change_2 = true;
            scene_prev = scene_current;
        }
        if (change_1)
        {
            spawn = GameObject.Find("spawn");
            spawn_point = spawn.transform.position;
            this.transform.position = new Vector3(spawn_point.x, spawn_point.y, 0);
            change_1 = false;
        }
        else if (change_2)
        {
            spawn_2 = GameObject.Find("spawn_2");
            spawn_point_2 = spawn_2.transform.position;
            this.transform.position = new Vector3(spawn_point_2.x, spawn_point_2.y, 0);
            change_2 = false;
        }
    }
}