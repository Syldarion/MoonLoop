using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DraggableObject : MonoBehaviour
{
    public event EventHandler<Vector3> OnDrag = (sender, vector3) => { }; 
    
    private bool isDragging;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (isDragging)
        {
            Vector2 mouseTranslation = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position;
            transform.Translate(mouseTranslation);
            OnDrag.Invoke(this, transform.position);
        }
    }

    public void StartDragging()
    {
        isDragging = true;
    }

    public void StopDragging()
    {
        isDragging = false;
    }
}
