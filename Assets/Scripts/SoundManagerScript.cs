using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip glassbreak, harvestfailure, harvestplant, harvestsuccess, homegate, labgate, homewalk, 
    labwalk, placeplant, sadness, sandwalk, lament_hisli, ohno;
    
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
     glassbreak = Resources.Load<AudioClip> ("glassbreak");
     lament_hisli = Resources.Load<AudioClip> ("lament_hisli");
     ohno = Resources.Load<AudioClip> ("ohno");
     harvestfailure = Resources.Load<AudioClip> ("harvestfailure");
     harvestplant = Resources.Load<AudioClip> ("harvestplant");
     harvestsuccess = Resources.Load<AudioClip> ("harvestsuccess");
     homegate = Resources.Load<AudioClip> ("homegate");
     labgate = Resources.Load<AudioClip> ("labgate");
     homewalk = Resources.Load<AudioClip> ("homewalk");
     labwalk = Resources.Load<AudioClip> ("labwalk");
     placeplant = Resources.Load<AudioClip> ("placeplant");
     sadness = Resources.Load<AudioClip> ("sadness");
     sandwalk = Resources.Load<AudioClip> ("sandwalk");
    
     audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip){
        Debug.Log("SOUND!");
        switch(clip){
            case "glassbreak":
                audioSrc.PlayOneShot (glassbreak);
                break;
            case "harvestfailure":
                audioSrc.PlayOneShot (harvestfailure);
                break;
            case "harvestplant":
                audioSrc.PlayOneShot (harvestplant);
                break;
            case "harvestsuccess":
                audioSrc.PlayOneShot (harvestsuccess);
                break;
            case "homegate":
                audioSrc.PlayOneShot (homegate);
                break;
            case "labgate":
                audioSrc.PlayOneShot (labgate);
                break;
            case "homewalk":
                Debug.Log("here!");
                audioSrc.PlayOneShot (homewalk);
                break;
            case "labwalk":
                audioSrc.PlayOneShot (labwalk);
                break;
            case "placeplant":
                audioSrc.PlayOneShot (placeplant);
                break;
            case "sadness":
                audioSrc.PlayOneShot (sadness);
                break;
            case "sandwalk":
                audioSrc.PlayOneShot (sandwalk);
                break;  
            case "lament_hisli":
                audioSrc.PlayOneShot (lament_hisli);
                break;   
             case "ohno":
                audioSrc.PlayOneShot (ohno);
                break;                                                       
        }
    }
}
