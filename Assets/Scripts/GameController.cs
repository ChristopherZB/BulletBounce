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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMonster(EnemyStatsController monster) { monster.GetComponent<EnemyMovementController>().Target = Player; Monsters.Add(monster); }

    [ContextMenu("Start Game")]
    public void StartGame()
    {
        //LevelSpawns.SpawnEnemies();
        for (int i =0; i < LevelSpawns.EnemiesType.Count; i++)
        {
            string type = LevelSpawns.EnemiesType[i];
            if (type == "dummy")
                methods.SpawnTestDummy(LevelSpawns.EnemiesCount[i], 2);
        }
    }

    public void EndGame()
    {

    }

    public void GoToMenu()
    {

    }
}
