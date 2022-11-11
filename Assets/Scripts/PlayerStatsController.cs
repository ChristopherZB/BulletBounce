using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsController : MonoBehaviour
{
    [Tooltip("x value is Health, y value is MaxHealth")]
    public Vector2 HealthStat;
    public Transform HealthbarPoint;

    HealthbarController HealthbarController;

    bool healthDirty = false;
    bool respawning = false;

    public float Health
    {
        get { return HealthStat.x; }
        set { HealthStat.x = value; }
    }
    public float MaxHealth
    {
        get { return HealthStat.y; }
        set { HealthStat.y = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        HealthbarController = HealthbarController.SpawnHealthbar(HealthbarPoint.position);
        HealthbarController.SetTarget(HealthbarPoint);
        HealthbarController.SetHealth(Health, MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (healthDirty)
        {
            HealthbarController.SetHealth(Health, MaxHealth);
            healthDirty = false;
        }
    }

    public bool IsAlive() => Health > 0 && !respawning;

    public void ChangeHealth(float change)
    {
        Health += change;
        healthDirty = true;
        if (Health <= 0)
        {
            // die
        }
    }

    public void SetHealth(float value)
    {
        Health = value;
        healthDirty = true;
    }
}
