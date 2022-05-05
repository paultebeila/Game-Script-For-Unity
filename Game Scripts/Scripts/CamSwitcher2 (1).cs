using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitcher : MonoBehaviour
{
    //ADD REFERENCES TO AUDIO LISTENERS AS WELL
    public Camera redCam;
    public Camera blueCam;
    public Camera greenCam;
    public Camera mainCam;
    Camera activeCam = new Camera();
    // Update is called once per frame
    void Start()
    {
        activeCam = mainCam;
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = activeCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {//THIS SHOULD ONLY EXECUTE IF A VALID OBJECT WAS CLICKED ON
                disableCams();
                activeCam = hit.transform.gameObject.GetComponentInChildren<Camera>();
                hit.transform.gameObject.GetComponentInChildren<Camera>().enabled = true;
                hit.transform.gameObject.GetComponentInChildren<AudioListener>().enabled = true;
            }
        }

        if(Input.GetButtonDown("Jump"))
        {
            disableCams();
            mainCam.enabled = true;
            activeCam = mainCam;
        }
    }

    //THIS FUNCTION SHOULD DISABLE AUDIO LISTENERS AS WELL
    public void disableCams()
    {
        redCam.enabled = false;
        greenCam.enabled = false;
        blueCam.enabled = false;
        Camera.main.enabled = true;
        
    }

}
