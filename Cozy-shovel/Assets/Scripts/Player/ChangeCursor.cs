using System;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    [SerializeField] Texture2D mouseIcon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.SetCursor(mouseIcon, new Vector2(0,32), CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
