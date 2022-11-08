using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitNumberController : MonoBehaviour
{
    public static void SpawnHitNumber(Vector3 position, int text)
    {
        SpawnHitNumber(position, new Color(255, 108, 4), 36, text.ToString());
    }

    public static void SpawnHitNumber(Vector3 position, string text)
    {
        SpawnHitNumber(position, new Color(255, 108, 4), 36, text);
    }

    public static void SpawnHitNumber(Vector3 position, Color vertexColor, int fontSize, string text)
    {
        Transform hitNum = Instantiate(Assets.i.HitNumberPrefab, position, Quaternion.identity, Assets.i.Canvas).transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
