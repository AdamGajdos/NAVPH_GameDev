using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


/* 
 * This script is responsible for saving and loading saved progress of player
 * It's based on video: https://www.youtube.com/watch?v=XOjd_qU2Ido
 */

public static class SavingSystem
{
    private static string path = Application.persistentDataPath + "/";

    public static string GetSavePath()
    {
        return path;
    }

    public static void SavePlayerProgress(PlayerController pc)
    {
        string pathToFile = path + pc.playerName + ".save";

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(pathToFile, FileMode.Create);

        PlayerData data = new PlayerData(pc);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static void SavePlayerProgress(PlayerData data)
    {
        string pathToFile = path + data.playerName + ".save";


        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(pathToFile, FileMode.Create);

        formatter.Serialize(stream, data);

        stream.Close();
    }



    public static PlayerData LoadPlayerProgress(string playerName)
    {
        string pathToFile = path + playerName + ".save";

        if (File.Exists(pathToFile))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(pathToFile, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File" + pathToFile + " not found! Your progress might be lost...");
            return null;
        }
    }
}
