using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour
{

    public Slider slider;

    Transform target;

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
            transform.position = Camera.main.WorldToScreenPoint(target.position);
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
