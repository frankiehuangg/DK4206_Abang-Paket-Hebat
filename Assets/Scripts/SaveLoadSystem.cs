using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;

public static class SaveLoadSystem 
{
    public static void SaveGameData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "game.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadGameData()
    {
        string path = Application.persistentDataPath + "game.fun";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        }
        else
        {
            GameData data = new GameData();
            SaveGameData();
            return data;
        }
    }
}
