using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomHelpers
{
    public static Vector3 ScreenToWorldPositioning(Vector3 targetPosition, bool IsNonUI = true, Camera cam = null)
    {
        if (!cam) cam = Camera.main;
        if (IsNonUI)
        {
            if (Assets.i.NonPlayerUICanvas.GetComponent<Canvas>().renderMode == RenderMode.WorldSpace)
            {
                return targetPosition;
            } else
            {
                return cam.WorldToScreenPoint(targetPosition);
            }
        } else
        {
            if (Assets.i.Canvas.GetComponent<Canvas>().renderMode == RenderMode.WorldSpace)
            {
                return targetPosition;
            }
            else
            {
                return cam.WorldToScreenPoint(targetPosition);
            }
        }
    }
}
