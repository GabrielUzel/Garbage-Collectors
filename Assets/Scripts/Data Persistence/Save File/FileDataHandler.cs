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
                string dataToLoad = "";

                using (FileStream stream = new FileStream(fullPath, FileMode.Open)) 
                {
                    using (StreamReader reader = new StreamReader(stream)) 
                    {
                        dataToLoad = reader.ReadToEnd();
                        loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
                    }
                }
            } 
            catch (Exception e) 
            {
                Debug.LogError($"Failed to load game data: {e.Message}");
            }
        } 

        return loadedData;
    }

    public void Save(GameData gameData)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        string json = JsonUtility.ToJson(gameData, true);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            string dataToStore = JsonUtility.ToJson(gameData, true);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to save game data: {e.Message}");
        }
    }
}
