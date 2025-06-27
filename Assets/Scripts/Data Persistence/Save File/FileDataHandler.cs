using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath;
    private string dataFileName;

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public GameData Load() 
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;

        if (File.Exists(fullPath)) 
        {
            try 
            {
                string encryptedData = "";

                using (FileStream stream = new FileStream(fullPath, FileMode.Open)) 
                using (StreamReader reader = new StreamReader(stream)) 
                {
                    encryptedData = reader.ReadToEnd();
                }

                string decryptedJson = Encryption.Decrypt(encryptedData);
                loadedData = JsonUtility.FromJson<GameData>(decryptedJson);
            } 
            catch (Exception e) 
            {
                Debug.LogError($" Failed to load game data: {e.Message}");
            }
        }

        return loadedData;
    }

    public void Save(GameData gameData)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string json = JsonUtility.ToJson(gameData, true);
            string encryptedData = Encryption.Encrypt(json);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(encryptedData);
            }
        }
        catch (Exception e)
        {
            Debug.LogError($" Failed to save game data: {e.Message}");
        }
    }
}
