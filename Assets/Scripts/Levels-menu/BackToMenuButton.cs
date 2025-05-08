using System.IO;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using log4net.Core;

public class BackToMenuButton : MonoBehaviour
{

    /* [Serializable]
     class SaveLevel
     {
         public int level;
     }

     

     public void Save()
     {
         SaveLevel level = new SaveLevel
         {
             level = level,
         };
         String json = JsonUtility.ToJson(level);
         File.WriteAllText(Application.persistentDataPath + "/save.json", json);
     }*/

    /*public void OnLevelWasLoaded(int level)
    {
        string path = Application.persistentDataPath + "/save.json";

        if(File.Exists(path))
        {
            string jason = File.ReadAllText(path);
            SaveLevel level = JsonUtility.FromJson<SaveLevel>(json);
            level = Level.level;
        }
    }*/

    

    public void OnBackToMainMenu()
    {
        SceneManager.LoadScene("Main_Menu_Scene");
    }
}