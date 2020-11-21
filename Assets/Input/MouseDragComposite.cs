using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Scripting;

public struct MouseDragCompositeResult
{
    public Vector2 position;
    public Vector2 delta;
 
    public override string ToString() => $"{{ Position: {position}, Delta:{delta} }}";
}
 
[Preserve]
#if UNITY_EDITOR
[InitializeOnLoad]
#endif
[DisplayStringFormat("{Modifier}+{Delta}+{Position}")]
public class MouseDragComposite : InputBindingComposite<MouseDragCompositeResult>
{
    [RuntimeInitializeOnLoadMethod]
    static void Init() { }
 
    static MouseDragComposite()
    {
        InputSystem.RegisterBindingComposite<MouseDragComposite>();
    }
 
    [InputControl(layout = "Button")]
    public int modifier;
 
    [InputControl(layout = "Vector2")]
    public int delta;
 
    [InputControl(layout = "Vector2")]
    public int position;
 
    private Vector2MagnitudeComparer comparer = new Vector2MagnitudeComparer();
 
    public override MouseDragCompositeResult ReadValue(ref InputBindingCompositeContext context)
    {
        if (context.ReadValueAsButton(modifier))
        {
            var newDelta = context.ReadValue<Vector2, Vector2MagnitudeComparer>(this.delta, comparer);
            var newPosition = context.ReadValue<Vector2, Vector2MagnitudeComparer>(this.position, comparer);
 
            return new MouseDragCompositeResult
            {
                delta = newDelta,
                position = newPosition,
            };
        }
        return default;
    }
 
    public override float EvaluateMagnitude(ref InputBindingCompositeContext context)
    {
        var value = ReadValue(ref context);
        return value.delta.magnitude;
    }
}
