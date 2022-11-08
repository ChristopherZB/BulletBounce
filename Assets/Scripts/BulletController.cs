using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    float timeTilDeath = 5;
    Rigidbody2D rb;
    Collider2D c2D;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        c2D = GetComponent<Collider2D>();
        StartCoroutine("BulletDeath");
    }

    IEnumerator BulletDeath()
    {
        yield return new WaitForSeconds(timeTilDeath);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        transform.up = rb.velocity.normalized;
    }
}
