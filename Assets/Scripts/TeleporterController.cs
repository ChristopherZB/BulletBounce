using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterController : MonoBehaviour
{
    public bool UseTargetPosition;
    public TeleporterController TargetTeleporter;
    public Transform TargetPosition;

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
        if (collision.transform.CompareTag("Player"))
        {
            if (UseTargetPosition)
            {
                if (TargetPosition)
                    //collision.transform.position = TargetPosition.position;
                    collision.GetComponent<PlayerMovementController>().Teleport(TargetPosition.position);
            }
            else
            {
                if (TargetTeleporter)
                    //collision.transform.position = TargetTeleporter.transform.position;
                    collision.GetComponent<PlayerMovementController>().Teleport(TargetTeleporter.transform.position);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        if (TargetTeleporter)
            Gizmos.DrawLine(transform.position, TargetTeleporter.transform.position);
        if (TargetPosition)
            Gizmos.DrawLine(transform.position, TargetPosition.transform.position);
        if ((!TargetPosition && UseTargetPosition) || (!TargetTeleporter && !UseTargetPosition) || (!UseTargetPosition && TargetTeleporter == this))
        {
            Vector3 tr = transform.position + new Vector3(1, 1) * 0.5f;
            Vector3 br = transform.position + new Vector3(-1, 1) * 0.5f;
            Vector3 tl = transform.position + new Vector3(1, -1) * 0.5f;
            Vector3 bl = transform.position + new Vector3(-1, -1) * 0.5f;
            Gizmos.color = Color.red;
            Gizmos.DrawLine(bl, tr);
            Gizmos.DrawLine(tl, br);
        }
    }
}
