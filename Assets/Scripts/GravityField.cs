using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityField : MonoBehaviour
{
    public event EventHandler OnFieldUpdated = (sender, args) => { }; 
    
    public float gravityConstant = 6.674E-11f;

    public float distanceMultiplier;
    public List<GravityEffector> effectors;
    
    void Start()
    {
        foreach(GravityEffector effector in effectors)
        {
            effector.OnMoved += HandleEffectorMoved;
            effector.OnMassChanged += HandleEffectorMassChanged;
        }
    }

    void Update()
    {
        
    }

    public void HandleEffectorMoved(object sender, Vector3 position)
    {
        OnFieldUpdated.Invoke(this, EventArgs.Empty);
    }

    public void HandleEffectorMassChanged(object sender, float mass)
    {
        OnFieldUpdated.Invoke(this, EventArgs.Empty);
    }

    public void AddEffector(GravityEffector effector)
    {
        effector.OnMoved += HandleEffectorMoved;
        effector.OnMassChanged += HandleEffectorMassChanged;
        effectors.Add(effector);
    }

    public void RemoveEffector(GravityEffector effector)
    {
        effectors.Remove(effector);
        effector.OnMoved -= HandleEffectorMoved;
        effector.OnMassChanged -= HandleEffectorMassChanged;
    }

    public Vector2 GetGravityAtPosition(Vector2 position)
    {
        Vector2 totalForce = Vector2.zero;

        foreach (GravityEffector effector in effectors)
        {
            Vector2 effectorPosition = effector.transform.position;
            float effectorDistance = Vector2.Distance(position, effectorPosition);
            float force = gravityConstant * (effector.Gravity / effectorDistance);
            totalForce += (effectorPosition - position).normalized * force;
        }

        return totalForce;
    }
}
