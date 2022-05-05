using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickLion : MonoBehaviour {

	// Use this for initialization
    public Camera camera;
    public Camera[] OtherCam;
    public Camera main;
    // Use this for initialization
    Camera activeCam = new Camera();
   
    public void click()
    {
        camera.enabled = true;
        main.enabled = false;
        OtherCam[0].enabled = false;
        OtherCam[1].enabled = false;
        activeCam = camera;



        main.gameObject.GetComponentInChildren<AudioListener>().enabled = false;
        OtherCam[0].gameObject.GetComponentInChildren<AudioListener>().enabled = false;
        OtherCam[1].gameObject.GetComponentInChildren<AudioListener>().enabled = false;

        camera.gameObject.GetComponentInChildren<AudioListener>().enabled = true;
        



    }
}
