using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assets : MonoBehaviour
{
    private static Assets _i;

    public static Assets i
    {
        get
        {
            if (_i == null)
            {
                _i = Instantiate(Resources.Load<Assets>("GameAssets"));
                _i.Canvas = GameObject.Find("Canvas").transform;
                _i.HealthbarCanvas = GameObject.Find("HealthbarCanvas").transform;
            }
            return _i;
        }
    }

    [HideInInspector]
    public Transform Canvas;

    [HideInInspector]
    public Transform HealthbarCanvas;

    public GameObject HitNumberPrefab;
    public GameObject HealthbarPrefab;
}
