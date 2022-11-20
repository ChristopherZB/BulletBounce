using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawnMethods : MonoBehaviour
{
    GameController GameController;

    private void Awake()
    {
        GameController = GetComponent<GameController>();
    }

    public void SpawnTestDummy(int count, float delay)
    {
        StartCoroutine(SpawnMonster(Assets.i.TempMonster, Vector3.zero, count, delay));
    }


    IEnumerator SpawnMonster(GameObject monster, Vector3 pos, int count, float delay)
    {
        for (int i = 0; i < count; i++)
        {
            GameController.AddMonster(Instantiate(monster, pos, Quaternion.identity).GetComponent<EnemyStatsController>());
            yield return new WaitForSeconds(delay);
        }
    }
}