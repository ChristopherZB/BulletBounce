using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Level", menuName = "Level Spawn")]
public class LevelSpawnsObject : ScriptableObject
{
    public UnityEvent EnemiesToSpawn;

    public void SpawnEnemies()
    {
        EnemiesToSpawn.Invoke();
    }
}
