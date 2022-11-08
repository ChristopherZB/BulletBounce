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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            HitNumberController.SpawnHitNumber(Input.mousePosition, 100);
        }
    }
}
