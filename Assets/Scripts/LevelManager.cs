using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GravityField levelGravityField;
    public GravityGrid levelGravityGrid;
    
    void Start()
    {
        levelGravityField.OnFieldUpdated += levelGravityGrid.HandleGravityFieldUpdated;
    }

    void Update()
    {
        
    }
}
