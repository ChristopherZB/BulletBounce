using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    public bool IsPatrol;
    public Transform Target;
    public List<Transform> PatrolPoints = new List<Transform>();
    public float Speed;
    public float StopDistance = 1.5f;

    EnemyStatsController StatsController;
    int nextPatrolIndex;
    Vector3 nextPatrolPoint;

    // Start is called before the first frame update
    void Awake()
    {
        StatsController = GetComponent<EnemyStatsController>();
    }

    private void Start()
    {
        nextPatrolIndex = 1;
    }

    private void FixedUpdate()
    {
        if (IsPatrol && StatsController.IsAlive())
        {
            nextPatrolPoint = PatrolPoints[nextPatrolIndex].position;
            Vector3 direction = nextPatrolPoint - transform.position;
            if (direction.sqrMagnitude > StopDistance)
                transform.position += direction.normalized * Speed * Time.fixedDeltaTime;
            else
                nextPatrolIndex = (nextPatrolIndex + 1) % PatrolPoints.Count;
        }
        if (Target && StatsController.IsAlive())
        {
            Vector3 direction = Target.position - transform.position;
            if (direction.sqrMagnitude > StopDistance)
                transform.position += direction.normalized * Speed * Time.fixedDeltaTime;
        }
    }
}
