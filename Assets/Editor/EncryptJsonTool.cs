using UnityEngine;
using UnityEditor;
using System.IO;

public class EncryptJsonTool
{
    [MenuItem("Tools/Criptografar JSON de Fases")]
    public static void EncryptLevelJson()
    {
        string sourcePath = "Assets/Editor/RawLevels/levels_data.json";
        string targetPath = Application.streamingAssetsPath + "/levels_data.enc";

        if (!File.Exists(sourcePath))
        {
            Debug.LogError(" Arquivo JSON não encontrado: " + sourcePath);
            return;
        }

        string json = File.ReadAllText(sourcePath);
        string encrypted = Encryption.Encrypt(json);

        Directory.CreateDirectory(Application.streamingAssetsPath);
        File.WriteAllText(targetPath, encrypted);

        Debug.Log("✅ JSON criptografado salvo em: " + targetPath);
    }
}
