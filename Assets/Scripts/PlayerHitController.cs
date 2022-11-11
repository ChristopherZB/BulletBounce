using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitController : MonoBehaviour
{
    PlayerStatsController statsController;

    private void Awake()
    {
        statsController = GetComponent<PlayerStatsController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            int damage = Random.Range(140, 320);
            if (statsController) statsController.ChangeHealth(-1 * damage);
            if (statsController && !statsController.IsAlive()) return;

            HitNumberController.SpawnHitNumber(RandomHelpers.ScreenToWorldPositioning(transform.position)).Setup(damage);

        }
    }
}
