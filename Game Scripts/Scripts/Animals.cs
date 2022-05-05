using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals : MonoBehaviour
{

    // Use this for initialization
    public cowControl cow;
    public dogControl lion;
    public ZebraControl zebra;


    public float cowHealth;
    public float lionHealth;
    public float zebraHealth;


    public float[] DogPosition;
    public float[] CowPosition;
    public float[] ZebraPosition;

    
    void Start()
    {
      
    }
    void Update()
    {
        cowHealth = cow.health;
        lionHealth = lion.health;
        zebraHealth = zebra.health;
        DogPosition = new float[3];

        DogPosition[0] = lion.gameObject.transform.position.x;
        DogPosition[1] = lion.gameObject.transform.position.y;
        DogPosition[2] = lion.gameObject.transform.position.z;
        ZebraPosition = new float[3];
        ZebraPosition[0] = zebra.gameObject.transform.position.x;
        ZebraPosition[1] = zebra.gameObject.transform.position.y;
        ZebraPosition[2] = zebra.gameObject.transform.position.z;
        CowPosition = new float[3];
        CowPosition[0] = cow.gameObject.transform.position.x;
        CowPosition[1] = cow.gameObject.transform.position.y;
        CowPosition[2] = cow.gameObject.transform.position.z;
    
    
    
    
    
    }

    public void SavePlayer()
    {
        SaveSystem.savePlayer(this);

    }

    public void LoadPlayer()
    {
        AnimalData data = SaveSystem.loadPlayer();

        cow.health= data.Chealth;
        lion.health = data.Lhealth;
        zebra.health = data.Zhealth;


        Vector3 Zposition;
        Vector3 LPosition;
        Vector3 Cposition;

        Cposition.x = data.CowPosition[0];
        Cposition.y = data.CowPosition[1];
        Cposition.z = data.CowPosition[2];

        LPosition.x = data.DogPosition[0];
        LPosition.y = data.DogPosition[1];
        LPosition.z = data.DogPosition[2];

        Zposition.x = data.ZebraPosition[0];
        Zposition.y = data.ZebraPosition[1];
        Zposition.z = data.ZebraPosition[2];



        lion.gameObject.transform.position = LPosition;
        cow.gameObject.transform.position = Cposition;
        zebra.gameObject.transform.position = Zposition;

    }





    


}