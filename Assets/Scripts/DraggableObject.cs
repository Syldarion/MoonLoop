using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DraggableObject : MonoBehaviour
{
    private bool isDragging;
    
    void Start()
    {
        
    }

    void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Debug.Log(Camera.main.ScreenToWorldPoint(mousePos));
        if (isDragging)
        {
            Vector2 mouseTranslation = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position;
            transform.Translate(mouseTranslation);
        }
    }

    private void OnMouseDown()
    {
        isDragging = true;
        Debug.Log("ONMOUSEDOWN");
    }

    private void OnMouseUp()
    {
        isDragging = false;
        Debug.Log("ONMOUSEUP");
    }
}
