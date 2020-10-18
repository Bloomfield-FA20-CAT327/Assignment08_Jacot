using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SLScript
{
    public static List<MyGameData> savedGames = new List<MyGameData>();

    public static void Save()
    {
        SLScript.savedGames.Add(MyGameData.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + Path.DirectorySeparatorChar + "Mysave.gd");
        bf.Serialize(file, SLScript.savedGames);
        file.Close();
    }

    public static void Load()
    {
        if(File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "Mysave.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + Path.DirectorySeparatorChar + "Mysave.gd", FileMode.Open);
            savedGames = (List < MyGameData >) bf.Deserialize(file);
            file.Close();
        }
    }
    
}
