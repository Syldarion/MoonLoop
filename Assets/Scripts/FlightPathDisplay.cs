using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightPathDisplay : MonoBehaviour
{
    public GravityField activeField;
    public FlightPathOrb orbPrefab;
    public float orbSpawnTimer;
    public float orbMass;
    public float orbPropulsionScale;
    public float orbLifetime;

    private float timeSinceLastOrb;
    
    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        timeSinceLastOrb += Time.deltaTime;
        if (timeSinceLastOrb > orbSpawnTimer)
        {
            SpawnOrb();
        }
    }

    private void SpawnOrb()
    {
        FlightPathOrb newOrb = Instantiate(orbPrefab, transform.position, Quaternion.identity);
        newOrb.activeField = activeField;
        newOrb.orbMass = orbMass;
        newOrb.propulsionForceScale = orbPropulsionScale;

        Destroy(newOrb.gameObject, orbLifetime);
        
        timeSinceLastOrb = 0.0f;
    }
}
