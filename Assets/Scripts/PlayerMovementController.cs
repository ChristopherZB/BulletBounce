using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{
    public float movementSpeed = 1;
    public bool activeMovement = true;
    public float teleportCooldown = 1;
    public bool CanTeleport = true;
    Vector2 movement = new Vector2();

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


    }

    private void FixedUpdate()
    {
        if (activeMovement)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = movement * movementSpeed;
        }
    }

    public void Teleport(Vector3 position)
    {
        if (!CanTeleport) return;
        CanTeleport = false;
        transform.position = position;
        StartCoroutine("teleCooldown");
    }

    IEnumerator teleCooldown()
    {
        yield return new WaitForSeconds(teleportCooldown);
        CanTeleport = true;
    }
}
