using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnFilter
{
    Any, ArcherOnly, GruntOnly, RedOnly
}

public class Spawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public SpawnFilter filter;
    private SO_EnemyType choice;

    public void Spawn(List<SO_EnemyType> allTypes) // Method to check which spawner it is, and spawn the right units 
    {
        List<SO_EnemyType> options = new List<SO_EnemyType>();
        for (int i = 0; i < allTypes.Count; i++) // For loop to assign the correct types based on the filter selected in inspector
        {
            SO_EnemyType temp = allTypes[i]; // temporary variable to loop through the types
            if (filter == SpawnFilter.Any)
                options.Add(temp);
            else if (filter == SpawnFilter.ArcherOnly && temp.enemyClass == EnemyClass.Archer) 
                options.Add(temp);
            else if (filter == SpawnFilter.GruntOnly && temp.enemyClass == EnemyClass.Grunt) 
                options.Add(temp);
            else if (filter == SpawnFilter.RedOnly && temp.name == "RedType") 
                options.Add(temp);
        }
        if (options.Count == 0) return; 

        // Remove zero-weight options to avoid useless work
        for (int i = options.Count - 1; i >= 0; i--)
            if (options[i].spawnRate <= 0f) options.RemoveAt(i);

        choice = PickBySpawnRate(options); // variable that stores the final chosen enemy type

        GameObject prefabToSpawn = GetPrefab(choice); 
        if (prefabToSpawn == null) return; 

        Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
    }
    
    /*
      Spawn Rate tells the game how likely each enemy is to appear
      first all the spawn rates are added up, and then a random number is picked.
      Whichever enemy's range it falls into is the one that spawns, that way the enemy with higher spawn rates get picked more often to spawn
     */
    SO_EnemyType PickBySpawnRate(List<SO_EnemyType> options) 
    {
        float totalRate = 0f;
        for (int i = 0; i < options.Count; i++)
        {
            totalRate += options[i].spawnRate; // Total spawn rate within which we generate a random number
        }

        float randomNumber = Random.Range(0f, totalRate);

        float currentRange = 0f;
        for (int i = 0; i < options.Count; i++) // check which types range does the random number fall under, and return it
        {
            currentRange += options[i].spawnRate;
            if (randomNumber <= currentRange)
            {
                return options[i];
            }
        }
        return options[options.Count - 1];
    }
    
    GameObject GetPrefab(SO_EnemyType enemy) // Get the correct prefab based on the enemy, in case they have different models
    {
        GameObject prefab = null;

        if (enemy.name == "RedType")
        {
            prefab = enemyPrefabs[0];
        }
        else if (enemy.name == "BrownType")
        {
            prefab = enemyPrefabs[1];
        }
        else if (enemy.name == "BlueType")
        {
            prefab = enemyPrefabs[2];
        }
        else if (enemy.name == "GreenType")
        {
            prefab = enemyPrefabs[3];
        }
        else if (enemy.name == "YellowType")
        {
            prefab = enemyPrefabs[4];
        }

        return prefab;
    }
}