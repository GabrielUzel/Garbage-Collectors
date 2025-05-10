using System.IO;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using log4net.Core;

public class BackToMenuButton : MonoBehaviour
{
    public void OnBackToMainMenu()
    {
        SceneManager.LoadScene("Main_Menu_Scene");
    }
}