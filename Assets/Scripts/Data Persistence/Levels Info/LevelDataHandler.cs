using UnityEngine;
using System;
using System.IO;

public class LevelDataHandler
{
    private string dataDirPath;
    private string dataFileName;

    public LevelDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public LevelData Load() 
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        LevelData loadedData = null;

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
                        loadedData = JsonUtility.FromJson<LevelData>(dataToLoad);
                    }
                }
            } 
            catch (Exception e) 
            {
                Debug.LogError($"Failed to load level data: {e.Message}");
            }
        } 

        return loadedData;
    }
}
