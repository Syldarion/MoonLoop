using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityIndicator : MonoBehaviour
{
    public Vector2 GravityForce
    {
        get => currentGravityForce;
        set => currentGravityForce = value;
    }
    
    public LineRenderer arrowBodyRenderer;
    public LineRenderer arrowHeadRenderer;

    [SerializeField]
    private Vector2 currentGravityForce;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetArrowLength(float length)
    {
        arrowBodyRenderer.SetPosition(1, new Vector3(length, 0.0f, 0.0f));
        arrowHeadRenderer.transform.localPosition = new Vector3(length, 0.0f, 0.0f);
    }
}
