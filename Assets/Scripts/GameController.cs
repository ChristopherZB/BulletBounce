using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public LevelSpawnsObject LevelSpawns;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Start Game")]
    public void StartGame()
    {
        LevelSpawns.SpawnEnemies();
    }

    public void EndGame()
    {

    }

    public void GoToMenu()
    {

    }
}
