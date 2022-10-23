using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    // Start is called before the first frame update
    public void MuteGame()
    {
        AudioListener.pause = true;
    }
    public void UnMuteGame()
    {
        AudioListener.pause = false;
    }
}
