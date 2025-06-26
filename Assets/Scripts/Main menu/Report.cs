using UnityEngine;
using UnityEngine.SceneManagement;

public class Report : MonoBehaviour
{
  
    public GameObject ReportPopUp;
    public GameObject fadedBackground;

    public void ShowReport()
    {                fadedBackground.SetActive(true);

        BestStatsManager.Instance.UpdateLabels();
        ReportPopUp.SetActive(true);

    }

    public void CloseReport()
    {
                        fadedBackground.SetActive(false);

        ReportPopUp.SetActive(false);

    }
}