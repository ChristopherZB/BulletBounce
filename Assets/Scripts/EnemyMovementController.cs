using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    public float Speed = 5f;
    public float StopDistance = 1f;
    public Vector3 Home;
    public PlayerStatsController Target;
    public bool IsPatrol;
    public List<Transform> PatrolPoints = new List<Transform>();

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
        Home = transform.position;
    }

    private void FixedUpdate()
    {
        if (!StatsController.IsAlive()) return;
        if (IsPatrol)
        {
            nextPatrolPoint = PatrolPoints[nextPatrolIndex].position;
            Vector3 direction = nextPatrolPoint - transform.position;
            if (direction.sqrMagnitude > StopDistance)
                transform.position += direction.normalized * Speed * Time.fixedDeltaTime;
            else
                nextPatrolIndex = (nextPatrolIndex + 1) % PatrolPoints.Count;
        }
        if (Target)
        {
            if (Target.IsAlive())
            {
                Vector3 direction = Target.transform.position - transform.position;
                if (direction.sqrMagnitude > StopDistance)
                    transform.position += direction.normalized * Speed * Time.fixedDeltaTime;
            }
            else
            {
                Vector3 direction = Home - transform.position;
                if (direction.sqrMagnitude > StopDistance)
                    transform.position += direction.normalized * Speed * Time.fixedDeltaTime;
            }
        }
    }
}
