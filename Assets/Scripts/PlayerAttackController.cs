using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public Transform Body;
    public Transform WeaponContainer;
    public WeaponController EquippedWeapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookingDirection = mousePoint - transform.position;

        Body.right = lookingDirection;

        if (Input.GetMouseButtonDown(0))
        {
            EquippedWeapon.Fire(mousePoint, WeaponContainer);
        }
    }
}
