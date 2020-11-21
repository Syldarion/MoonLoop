using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightPathOrb : MonoBehaviour
{
    public GravityField activeField;
    public float propulsionForceScale;
    public float orbMass;
    public float orbDrag;

    [SerializeField]
    private Vector2 velocity;
    
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 propulsionForce = transform.right * propulsionForceScale;
        Vector2 gravityForce = activeField.GetGravityAtPosition(transform.position);
        Vector2 dragForce = -velocity * orbDrag;

        velocity += (propulsionForce + gravityForce + dragForce) * Time.fixedDeltaTime;
        
        float angle = Vector2.SignedAngle(transform.right, velocity);
        transform.Rotate(0.0f, 0.0f, angle);

        transform.Translate(velocity);
    }
}
