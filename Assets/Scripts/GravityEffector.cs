using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityEffector : MonoBehaviour
{
    public event EventHandler<Vector3> OnMoved = (sender, vector3) => { };
    public event EventHandler<float> OnMassChanged = (sender, f) => { };

    public float Gravity => isRepulsor ? -mass : mass;

    public float Mass
    {
        get => mass;
        set
        {
            mass = value;
            OnMassChanged.Invoke(this, value);
        }
    }

    public bool isRepulsor;
    
    [SerializeField]
    private float mass;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void MoveEffector(Vector3 newPosition)
    {
        transform.position = newPosition;
        OnMoved.Invoke(this, transform.position);
    }
}
