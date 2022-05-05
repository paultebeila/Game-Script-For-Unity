using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStopper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Destroyer("Food");
        }

	}

    void Destroyer(string myTag)
    {
        GameObject [] obj = GameObject.FindGameObjectsWithTag(myTag);
        foreach(GameObject target in obj)
        {
            GameObject.Destroy(target);
        }


    }
}
