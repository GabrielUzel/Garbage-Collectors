using UnityEngine;
using UnityEngine.SceneManagement;

public class WasteCatalogButtonController : MonoBehaviour
{
    public void LoadWasteCatalogScene()
    {
        SceneManager.LoadScene("Waste_Catalog_Scene");
    }
}
