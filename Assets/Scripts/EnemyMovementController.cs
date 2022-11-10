using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    public Transform Target;
    public float Speed;

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
            transform.position += direction.normalized * Speed * Time.fixedDeltaTime;
        }
    }
}
