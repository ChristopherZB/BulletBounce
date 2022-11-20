using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public PlayerStatsController Player;
    public LevelSpawnsObject LevelSpawns;

    public List<EnemyStatsController> Monsters;

    EnemySpawnMethods methods;

    private void Awake()
    {
        methods = GetComponent<EnemySpawnMethods>();
    }

    public void AddMonster(EnemyStatsController monster) { monster.GetComponent<EnemyMovementController>().Target = Player; Monsters.Add(monster); }

    [ContextMenu("Start Game")]
    public void StartGame()
    {
        for (int i = 0; i < LevelSpawns.EnemiesType.Count; i++)
        {
            var type = LevelSpawns.EnemiesType[i];
            switch (type)
            {
                case EnemyType.TestDummy:
                    methods.SpawnTestDummy(LevelSpawns.EnemiesCount[i], 2);
                    break;
            }
        }
    }

    public void EndGame()
    {

    }

    public void GoToMenu()
    {

    }
}
