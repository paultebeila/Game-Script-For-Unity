using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePOV : MonoBehaviour
{

    public Transform Player;
    public Camera FirstCam, ThirdCam,topCam;
    
    public bool camSwitch = false;
    private Vector3 offset;



    void Start()
    {
        offset = transform.position - Player.transform.position;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            camSwitch = !camSwitch;
            FirstCam.gameObject.SetActive(camSwitch);
            ThirdCam.gameObject.SetActive(!camSwitch);
            topCam.gameObject.SetActive(!camSwitch);
        }else if (Input.GetKeyDown(KeyCode.V))
        {
            camSwitch = camSwitch;
            FirstCam.gameObject.SetActive(!camSwitch);
            ThirdCam.gameObject.SetActive(camSwitch);
            topCam.gameObject.SetActive(!camSwitch);
        }else if(Input.GetKeyDown(KeyCode.B))
        {
            camSwitch = camSwitch;
            topCam.gameObject.SetActive(camSwitch);
            FirstCam.gameObject.SetActive(!camSwitch);
            ThirdCam.gameObject.SetActive(!camSwitch);
            
        }
       
    }
    void LateUpdate()
    {
        transform.position = Player.transform.position + offset;
    }
}
