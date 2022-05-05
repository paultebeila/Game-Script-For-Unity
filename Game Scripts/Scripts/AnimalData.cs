using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AnimalData
{

    public float Lhealth;
    public float Zhealth;
    public float Chealth;

    public float[] DogPosition;
    public float[] CowPosition;
    public float[] ZebraPosition;


    public AnimalData(Animals animals)
    {
        Chealth = animals.cowHealth;
        Zhealth = animals.zebraHealth;
        Lhealth = animals.lionHealth;

        DogPosition = new float[3];
        DogPosition[0] = animals.DogPosition[0];
        DogPosition[1] = animals.DogPosition[1];
        DogPosition[2] = animals.DogPosition[2];


        ZebraPosition = new float[3];
        ZebraPosition[0] = animals.ZebraPosition[0];
        ZebraPosition[1] = animals.ZebraPosition[0];
        ZebraPosition[2] = animals.ZebraPosition[0];


        CowPosition = new float[3];
        CowPosition[0] = animals.CowPosition[0];
        CowPosition[1] = animals.CowPosition[1];
        CowPosition[2] = animals.CowPosition[2];
    
    
    }
}

