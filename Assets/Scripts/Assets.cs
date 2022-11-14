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
                _i.NonPlayerUICanvas = GameObject.Find("NonPlayerUICanvas").transform;
            }
            return _i;
        }
    }

    [HideInInspector]
    public Transform Canvas;

    [HideInInspector]
    public Transform NonPlayerUICanvas;

    public GameObject HitNumberPrefab;
    public GameObject HealthbarPrefab;

    [Space]
    public GameObject TempMonster;
}
