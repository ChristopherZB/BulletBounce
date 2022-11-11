using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitController : MonoBehaviour
{
    Collider2D c2D;//https://www.youtube.com/watch?v=iD1_JczQcFY
    EnemyStatsController statsController;

    private void Awake()
    {
        c2D = GetComponent<Collider2D>();
        statsController = GetComponent<EnemyStatsController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            int damage = Random.Range(140, 320);
            if (statsController) statsController.ChangeHealth(-1 * damage);
            if (statsController && !statsController.IsAlive()) return;

            // Use when canvas set to screen space - overlay
            //HitNumberController.SpawnHitNumber(Camera.main.WorldToScreenPoint(transform.position)).Setup(damage);

            // Use when canvas set to World Space
            HitNumberController.SpawnHitNumber(RandomHelpers.ScreenToWorldPositioning(transform.position)).Setup(damage);
            
        }
    }
}
