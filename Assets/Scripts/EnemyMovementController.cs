using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    public Transform Target;
    public float Speed;
    public float StopDistance = 1.5f;

    EnemyStatsController StatsController;

    // Start is called before the first frame update
    void Awake()
    {
        StatsController = GetComponent<EnemyStatsController>();
    }

    private void FixedUpdate()
    {
        if (Target && StatsController.IsAlive())
        {
            Vector3 direction = Target.position - transform.position;
            if (direction.sqrMagnitude > StopDistance)
                transform.position += direction.normalized * Speed * Time.fixedDeltaTime;
        }
    }
}
