using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitController : MonoBehaviour
{
    [SerializeField]
    float iTime = 0.5f;
    Collider2D c2D;
    PlayerStatsController statsController;
    bool colliding = false;

    private void Awake()
    {
        c2D = GetComponent<Collider2D>();
        statsController = GetComponent<PlayerStatsController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!colliding && collision.transform.CompareTag("Enemy"))
        {
            colliding = true;
            StartCoroutine("ITime");
            int damage = Random.Range(140, 320);
            if (statsController) statsController.ChangeHealth(-1 * damage);
            if (statsController && !statsController.IsAlive()) return;

            HitNumberController.SpawnHitNumber(RandomHelpers.ScreenToWorldPositioning(transform.position)).Setup(damage);

        }
    }

    IEnumerator ITime()
    {
        yield return new WaitForSeconds(iTime);
        colliding = false;
    }
}
