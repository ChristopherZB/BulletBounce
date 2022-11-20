using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsController : MonoBehaviour
{
    [SerializeField]
    bool isTargetDummy;
    public float Health;
    public float MaxHealth;
    public Transform HealthbarPoint;
    public EnemyTypeSize EnemyType;


    HealthbarController HealthbarController;

    bool healthDirty = false;
    bool respawning = false;

    // Start is called before the first frame update
    void Start()
    {
        HealthbarController = HealthbarController.SpawnHealthbar(HealthbarPoint.position);
        HealthbarController.SetTarget(HealthbarPoint, EnemyType);
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
            if (isTargetDummy && !respawning) { StartCoroutine("TargetDummyRespawn"); return; }
        }
    }

    public void SetHealth(float value)
    {
        Health = value;
        healthDirty = true;
    }

    IEnumerator TargetDummyRespawn()
    {
        respawning = true;
        yield return new WaitForSeconds(5);
        SetHealth(MaxHealth);
        respawning = false;
    }
}
