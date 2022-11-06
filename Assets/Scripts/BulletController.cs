using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.rotation.ToAngleAxis(out float angle, out Vector3 axis);
        var overlap = Physics2D.OverlapCapsule(transform.position, new Vector2(0.25f, 0.5f), CapsuleDirection2D.Vertical, angle);
        if (overlap)
        {

        }
    }
}
