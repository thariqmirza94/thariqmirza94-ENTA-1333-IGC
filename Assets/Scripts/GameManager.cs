using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // List of both the enemy types and the spawners, so everything is in one place and organized
    public List<SO_EnemyType> enemyTypes;
    public List<Spawner> spawnPoints;

    void Start()
    {
        for (int i = 0; i < spawnPoints.Count; i++) // loops to find every enemy type
        {
            spawnPoints[i].Spawn(enemyTypes);
        }
    }
}
