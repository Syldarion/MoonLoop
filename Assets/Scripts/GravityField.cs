using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityField : MonoBehaviour
{
    public event EventHandler OnFieldUpdated = (sender, args) => { }; 
    
    public const float GRAVITY_CONSTANT = 6.674E-11f;

    public float distanceMultiplier;
    public List<GravityEffector> effectors;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void HandleEffectorUpdated(object effector, EventArgs args)
    {
        OnFieldUpdated.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetGravityAtPosition(float mass, Vector2 position)
    {
        Vector2 totalForce = Vector2.zero;

        foreach (GravityEffector effector in effectors)
        {
            Vector2 effectorPosition = effector.transform.position;
            float effectorDistance = Vector2.Distance(position, effectorPosition) * distanceMultiplier;
            float force = GRAVITY_CONSTANT * ((mass * effector.mass) / effectorDistance);
            totalForce += (effectorPosition - position).normalized * force;
        }

        return totalForce;
    }
}
