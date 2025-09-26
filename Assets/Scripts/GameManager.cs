using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // List of both the enemy types and the spawners, so everything is in one place and organixzed
    public List<SO_EnemyType> enemyTypes;
    public List<Spawner> spawnPoints;
    private SO_EnemyType tempType; // Temporary holder

    void Start()
    {
        if (enemyTypes.Count == 0) // simple check to make sure there is something assigned
            return;
        tempType = enemyTypes[0];
        for (int i = 0; i < spawnPoints.Count; i++) // Check to see if the spawner is working, will be modified later
            spawnPoints[i].Spawn(tempType);
    }
}
