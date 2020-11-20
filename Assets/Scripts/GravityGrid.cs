using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGrid : MonoBehaviour
{
    public List<GravityIndicator> indicators;

    public float minFieldStrength;
    public float maxFieldStrength;
    public float minArrowLength;
    public float maxArrowLength;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void HandleGravityFieldUpdated(object sender, EventArgs args)
    {
        GravityField field = sender as GravityField;
        if (field == null)
        {
            return;
        }
        
        foreach (GravityIndicator indicator in indicators)
        {
            UpdateIndicator(indicator, field);
        }
    }
    
    public void UpdateIndicator(GravityIndicator indicator, GravityField field)
    {
        Vector2 indicatorGravity = field.GetGravityAtPosition(1.0f, indicator.transform.position);
        float angle = Vector2.SignedAngle(indicator.transform.right, indicatorGravity);
        indicator.transform.Rotate(0.0f, 0.0f, angle);

        float strengthT = Mathf.InverseLerp(minFieldStrength, maxFieldStrength, indicatorGravity.magnitude);
        float arrowLength = Mathf.Lerp(minArrowLength, maxArrowLength, strengthT);

        indicator.SetArrowLength(arrowLength);
    }

#if UNITY_EDITOR
    public int gridWidth;
    public int gridHeight;
    public float startX;
    public float startY;
    public float xSpacing;
    public float ySpacing;
    public GravityIndicator indicatorPrefab;
    
    public void PlaceArrows()
    {
        
    }
#endif
}
