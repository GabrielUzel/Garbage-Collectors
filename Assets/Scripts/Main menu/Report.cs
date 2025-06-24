using UnityEngine;
using UnityEngine.SceneManagement;

public class Report : MonoBehaviour
{
  
    public GameObject ReportPopUp;

    public void ShowReport()
    {
        ReportPopUp.SetActive(true);
    }

    public void CloseReport()
    {
        ReportPopUp.SetActive(false);
    }
}