using UnityEngine;
using System;
using System.IO;

public class LevelDataHandler
{
    private readonly string dataDirPath;
    private readonly string dataFileName;

    public LevelDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public LevelData Load()
    {
        string fullPath = Path.Combine(Application.streamingAssetsPath, "levels_data.enc");
        LevelData loadedData = null;

        if (File.Exists(fullPath))
        {
            try
            {
                string encryptedData = File.ReadAllText(fullPath);
                string decryptedJson = Encryption.Decrypt(encryptedData);
                loadedData = JsonUtility.FromJson<LevelData>(decryptedJson);
            }
            catch (Exception e)
            {
                Debug.LogError("Erro ao descriptografar LevelData: " + e.Message);
            }
        }

        return loadedData;
    }

}
