using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public float launchForce;

    [SerializeField]
    GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var launchDirection = mousePoint - transform.position;
            Debug.Log(launchDirection + "  " + launchDirection.magnitude);
            launchDirection.z = 0;
            launchDirection.Normalize();
            Debug.Log(launchDirection + "  " + launchDirection.magnitude);
            GameObject projectile = Instantiate(bullet, transform.position + launchDirection, Quaternion.FromToRotation(Vector3.up, launchDirection), transform);
            projectile.GetComponent<Rigidbody2D>().AddForce(launchDirection * launchForce, ForceMode2D.Impulse);
        }
    }
}
