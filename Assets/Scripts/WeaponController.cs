using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float FireForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(Vector3 mousePos, Transform parent)
    {
        var launchDirection = mousePos - transform.position;
        launchDirection.z = 0;
        launchDirection.Normalize();
        GameObject projectile = Instantiate(BulletPrefab, transform.position, Quaternion.LookRotation(transform.forward), parent);
        projectile.GetComponent<Rigidbody2D>().AddForce(launchDirection * FireForce, ForceMode2D.Impulse);
    }
}
