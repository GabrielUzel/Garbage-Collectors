using UnityEngine;
using UnityEngine.SceneManagement;

public class Report : MonoBehaviour
{
  
    public GameObject ReportPopUp;

    public void ShowReport()
    {
        ReportPopUp.SetActive(true);
        BestStatsManager.Instance.UpdateLabels();
    }

    public void CloseReport()
    {
        ReportPopUp.SetActive(false);
    }
}