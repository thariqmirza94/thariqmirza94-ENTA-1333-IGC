using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    
    public void Spawn(SO_EnemyType type) // Method that can be called in order to execute a spawn
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}