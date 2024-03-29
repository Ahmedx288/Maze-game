﻿using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveLoadSYSTEM {
    public static void Save(TransferPlayerData player){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/PlayerData.txt";
        FileStream stream = new FileStream(path, FileMode.Create);


        PlayerData data = new PlayerData(player);
        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static PlayerData Load(){
        string path = Application.persistentDataPath + "/PlayerData.txt";

        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            
            return data;
        }else{
            Debug.LogError("File Not Found");
            return null;
        }
    }
}
