using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main_menu
{
    public class CursorResetOnSceneStart : MonoBehaviour
    {
        void Start()
        {
            Texture2D mouseCursor = Resources.Load<Texture2D>("cursor_mouse");
            if (mouseCursor != null)
            {
                Cursor.SetCursor(mouseCursor, new Vector2(5, 5), CursorMode.Auto);
            }
        }
    }

}
