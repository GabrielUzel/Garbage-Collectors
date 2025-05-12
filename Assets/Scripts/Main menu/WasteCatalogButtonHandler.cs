using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WasteCatalogButtonHandler : MonoBehaviour
{
    public void LoadWasteCatalogScene()
    {
        SceneManager.LoadScene("Waste_Catalog_Scene");
    }
}
