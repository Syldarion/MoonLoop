using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private MoonLoopControls controls;
    private DraggableObject currentDragObject;

    private void Awake()
    {
        controls = new MoonLoopControls();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            StartDragging();
        }
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            StopDragging();
        }
    }

    private void StartDragging()
    {
        Ray mouseWorldRay = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit2D hit = Physics2D.GetRayIntersection(mouseWorldRay);

        if (hit.collider != null)
        {
            DraggableObject draggableObject = hit.collider.gameObject.GetComponent<DraggableObject>();

            if (draggableObject != null)
            {
                draggableObject.StartDragging();
                currentDragObject = draggableObject;
            }
        }
    }

    private void StopDragging()
    {
        if (currentDragObject)
        {
            currentDragObject.StopDragging();
        }
    }
}
