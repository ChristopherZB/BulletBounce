using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Level", menuName = "Level Spawn")]
public class LevelSpawnsObject : ScriptableObject
{
    public List<string> EnemiesType;
    public List<int> EnemiesCount;

    private void OnValidate()
    {
        int count = EnemiesCount.Count, type = EnemiesType.Count;
        if (count < type)
        {
            for (int i = 0; i < type - count; i++)
                EnemiesCount.Add(0);
        }
        if (count > type)
        {
            for (int i = count-1; i >= type; i--)
                EnemiesCount.RemoveAt(i);
        }

    }

    //public UnityEvent EnemiesToSpawn;

    //public void SpawnEnemies()
    //{
    //    EnemiesToSpawn.Invoke();
    //}
}
