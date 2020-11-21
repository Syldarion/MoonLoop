using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GravityEffector), typeof(DraggableObject))]
public class MoonObject : MonoBehaviour
{
    private GravityEffector cGravityEffector;
    private DraggableObject cDraggableObject;

    private void Awake()
    {
        cGravityEffector = GetComponent<GravityEffector>();
        cDraggableObject = GetComponent<DraggableObject>();
        cDraggableObject.OnDrag += HandleDraggableObjectDragged;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void HandleDraggableObjectDragged(object sender, Vector3 position)
    {
        cGravityEffector.MoveEffector(position);
    }
}
