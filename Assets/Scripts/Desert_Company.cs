using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Desert_Company : MonoBehaviour
{
    // Start is called before the first frame update
    public bool is_trigger = false;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        is_trigger = true;
        SceneManager.LoadScene("Company");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
