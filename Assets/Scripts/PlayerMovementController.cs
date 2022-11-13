using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{
    public float movementSpeed = 7;
    public float teleportCooldown = 1;
    public float dashDistance = 3;
    public float dashCooldown = 5;
    public bool activeMovement = true;
    public bool canTeleport = true;
    public bool canDash = true;
    public LayerMask dashLayerMask;


    Vector2 movement = new Vector2();
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            movement.y = 0;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            movement.x = 0;
        }

        movement.y = Input.GetKey(KeyCode.W) ? 1 : (Input.GetKey(KeyCode.S) ? -1 : 0);
        movement.x = Input.GetKey(KeyCode.D) ? 1 : (Input.GetKey(KeyCode.A) ? -1 : 0);

        if (Input.GetKey(KeyCode.Space) && CanDash())
        {
            Dash();
        }
    }

    private void FixedUpdate()
    {
        if (activeMovement)
        {
            rb.velocity = movement * movementSpeed;
        }
    }

    void Dash()
    {
        Vector2 direction = movement.normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, dashDistance, dashLayerMask);
        float dist = dashDistance;
        if (hit)
        {
            dist = hit.distance;
        }
        rb.position += direction * dist;
        canDash = false;
        StartCoroutine("dashCooldownn");
    }

    bool CanDash()
    {
        return movement.sqrMagnitude > 0 && activeMovement && canDash;
    }

    public void Teleport(Vector3 position)
    {
        if (!canTeleport) return;
        canTeleport = false;
        transform.position = position;
        StartCoroutine("teleCooldown");
    }

    IEnumerator teleCooldown()
    {
        yield return new WaitForSeconds(teleportCooldown);
        canTeleport = true;
    }

    IEnumerator dashCooldownn()
    {
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
