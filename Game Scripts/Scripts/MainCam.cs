using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam : MonoBehaviour {

	
    //public Camera camera;
     public Camera main;
    public Camera dog;
    public Camera zebra;
     public Camera cow;


   
    Camera activeCam = new Camera();
    
    public void click()
    {
        //camera.enabled = false;
        main.enabled = true;
        dog.enabled = false;
        cow.enabled = false;
        zebra.enabled = false;

        main.gameObject.GetComponentInChildren<AudioListener>().enabled = true;
        dog.gameObject.GetComponentInChildren<AudioListener>().enabled = false;
        zebra.gameObject.GetComponentInChildren<AudioListener>().enabled = false;
        cow.gameObject.GetComponentInChildren<AudioListener>().enabled = false;

        activeCam = main;


        


        

       // camera.gameObject.GetComponentInChildren<AudioListener>().enabled = false;


    }
}
