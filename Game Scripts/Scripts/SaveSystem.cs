
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;



public static class SaveSystem
{


    public static void savePlayer(Animals animals)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = "C:\\Users\\lolob\\Downloads\\Compressed\\player.iiso";//Application.persistentDataPath + "/player.txt"; 
        FileStream stream = new FileStream(path, FileMode.Create);


        AnimalData data = new AnimalData(animals);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static AnimalData loadPlayer()
    {
        string path = "C:\\Users\\lolob\\Downloads\\Compressed\\player.iiso";//Application.persistentDataPath + "/player.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            AnimalData data = formatter.Deserialize(stream) as AnimalData;


            stream.Close();
            //Debug.Log(data.Chealth);
            return data;
        }
        else
        {
            
            return null;
        }
    }


}
