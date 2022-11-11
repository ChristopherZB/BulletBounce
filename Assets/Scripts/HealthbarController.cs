using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour
{

    public Slider slider;

    Transform target;

    public static HealthbarController SpawnHealthbar(Vector3 position)
    {
        return Instantiate(Assets.i.HealthbarPrefab, position, Quaternion.identity, Assets.i.NonPlayerUICanvas).GetComponent<HealthbarController>();
    }

    public void SetHealth(float curr, float max)
    {
        SetHealth(curr / max);
    }
    public void SetHealth(float percentage)
    {
        slider.value = percentage;
    }

    private void Update()
    {
        if (target != null)
        {
            // Use when canvas set to screen space - overlay
            //transform.position = Camera.main.WorldToScreenPoint(target.position);

            // Use when canvas set to World Space
            //transform.position = target.position;

            transform.position = RandomHelpers.ScreenToWorldPositioning(target.position);
        }
    }

    public void SetTarget(Transform t, EnemyType type = EnemyType.Normal)
    {
        target = t;
        switch(type)
        {
            case EnemyType.Normal:
                ((RectTransform)transform).SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 60f);
                break;
            case EnemyType.Small:
                ((RectTransform)transform).SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 30f);
                break;
            case EnemyType.Big:
                ((RectTransform)transform).SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 90f);
                break;
            case EnemyType.Large:
                ((RectTransform)transform).SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 120f);
                break;
            case EnemyType.Boss:
                ((RectTransform)transform).SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 180f);
                break;
        }
    }


}

public enum EnemyType
{
    Normal,
    Small,
    Big,
    Large,
    Boss
}
