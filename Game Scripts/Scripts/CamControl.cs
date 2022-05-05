using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public float curSpeed = 0.1f;
    public float maxSpeed = 100;
    public float minSpeed = 2;
    public float slowRange = 20;
    public GameObject target;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
        move();
        //Accelerate();
        //BadAccelerate();
        Decelerate();
    }
    void move()
    {//move at current speed
        transform.Translate(new Vector3(0, 0, curSpeed) * Time.deltaTime);
       // gameObject.transform.Translate(Vector3.forward);

    }
    void Accelerate()
    {
        if (curSpeed < maxSpeed)
            curSpeed += 0.8f;
    }
    void BadAccelerate()
    {
        while (curSpeed < maxSpeed)
        {
            curSpeed += 0.1f;
            break;
        }
    }

    void Decelerate()
    {
        if (Vector3.Distance(transform.position, target.gameObject.transform.position) < slowRange)
        {
            if (curSpeed > minSpeed)
                curSpeed -= 0.5f;
        }
        if (Vector3.Distance(transform.position, target.gameObject.transform.position) < 1)
            curSpeed = 0;
    }





}
