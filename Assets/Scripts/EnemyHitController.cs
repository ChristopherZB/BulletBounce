using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitController : MonoBehaviour
{
    Collider2D c2D;//https://www.youtube.com/watch?v=iD1_JczQcFY

    private void Awake()
    {
        c2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            HitNumberController.SpawnHitNumber(Camera.main.WorldToScreenPoint(transform.position)).Setup(Random.Range(140, 320));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            HitNumberController.SpawnHitNumber(Input.mousePosition).Setup(Random.Range(40, 120));
        }
    }
}
