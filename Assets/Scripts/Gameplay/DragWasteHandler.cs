using UnityEngine;

public class DragWasteHandler : MonoBehaviour
{
    public TrashType wasteType;
    private Vector3 offset;
    private bool dragging = false;
    
    void OnMouseDown()
    {
        Collider2D hit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (hit != null && hit.gameObject == gameObject)
        {
            offset = transform.position - GetMouseWorldPos();
            if(TimeManager.Instance.timerIsRunning == true){
                dragging = true;
            }
        }
    }

    void OnMouseUp()
    {
        dragging = false;
        
        Collider2D[] hits = Physics2D.OverlapPointAll(transform.position);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("TrashBin"))
            {
                TrashBinHandler binType = hit.GetComponent<TrashBinHandler>();
                if (binType != null && binType.acceptedType == wasteType)
                {
                    ScoreManager.Instance.AddScore();
                    TrashCountManager.Instance.AddCorrectTrashCount();
                    Destroy(gameObject);
                    return;
                }
                else
                {
                    LifeQuantityManager.Instance.LoseHeart();
                    TrashCountManager.Instance.AddIncorrectTrashCount();
                    Destroy(gameObject);
                    return;
                }
            }
        }
    }

    void Update()
    {
        if (dragging)
        {
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 10f; 
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
