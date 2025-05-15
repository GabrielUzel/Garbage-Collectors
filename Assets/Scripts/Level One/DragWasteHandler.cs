using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Level_One
{
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
                dragging = true;
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
                        // Aqui é caso o item está jogado na lixeira correta, ai vc coloca pra somar os pontos
                        ScoreManager.Instance.AddScore();
                        Destroy(gameObject);
                        return;
                    }
                    else
                    {
                        //Aqui é caso foi jogado na lixeira incorreta
                        // TODO: Player perde uma vida
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
}
