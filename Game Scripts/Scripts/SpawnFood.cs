using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour {

    public GameObject[] myGrass;
    //public Vector3 center;
    //public Vector3 size;
    //public TerrainData t;
    

	// Use this for initialization
	void Start () {
        //InvokeRepeating("spawn", 6f, 7f);
        for (int i = 0; i <= myGrass.Length; i++)
        {
            
            myGrass[i].gameObject.SetActive(false);
            
            
        }
        
   
	}
	
	// Update is called once per frame
	void Update () {

        //pos = new Vector3(Random.Range(-t.size.x, t.size.x), 0, Random.Range(-t.size.z, t.size.z));
        //Instantiate(myGrass, transform.position, transform.rotation);
        

            
            //InvokeRepeating("spawn",1f,1f);

       
            InvokeRepeating("spawn", 6f, 1f);

        
         
        
		
	}

   

    void spawn()
    {


        //Vector3 pos = center + new Vector3(Random.Range(-t.size.x / 2, t.size.x / 4),0,Random.Range(-t.size.z / 4, t.size.z / 4));

        //Instantiate(myGrass, pos, transform.rotation);


        //Instantiate(myGrass, new Vector3(Random.Range(-t.size.x, t.size.z), 0, Random.Range(-t.size.x, t.size.z)), transform.rotation); 
        
            int x = Random.Range(0, myGrass.Length);
            myGrass[x].gameObject.SetActive(true);
       
   

            
            



    }
}
