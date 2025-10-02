using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // List of both the enemy types and the spawners, so everything is in one place and organized
    public List<SO_EnemyType> enemyTypes;
    public List<Spawner> spawners;
    public List<SO_DayCycle> dayCycles;
    private SO_DayCycle chosenCycle;

    void Start()
    {
        if (dayCycles.Count == 0) return; 

        int iCycle = Random.Range(0, dayCycles.Count);
        chosenCycle = dayCycles[iCycle];

        for (int i = 0; i < enemyTypes.Count; i++) // Resetting SO values before modifications
        {
            enemyTypes[i].ResetRuntime();
        }

        for (int i = 0; i < enemyTypes.Count; i++)  // goes through all the enemy types and modifies the values of the enemy type based on the chosen cycle
        {
            // IF the enemy type is Archer, it adds spawn rate from a range based on the scriptable object
            if (enemyTypes[i].enemyClass == EnemyClass.Archer) 
            {
                enemyTypes[i].spawnRate += Random.Range(chosenCycle.archerSpawnAddRange.x, chosenCycle.archerSpawnAddRange.y);
            }
            // IF the enemy type is Brown, it adds spawn rate from a range based on the scriptable object 
            if (enemyTypes[i].name == "BrownType") 
            {
                enemyTypes[i].spawnRate += Random.Range(chosenCycle.brownSpawnAddRange.x, chosenCycle.brownSpawnAddRange.y);
            }
            // IF the enemy type is Assassin, it will block it from spawning based on scriptable object
            if (chosenCycle.blockAssassins && enemyTypes[i].enemyClass == EnemyClass.Assassin) 
            {
                enemyTypes[i].spawnRate = 0f;
            }
            // IF the enemy type is Grunt, it will add attack power based on scriptable object
            if (enemyTypes[i].enemyClass == EnemyClass.Grunt) 
            {
                enemyTypes[i].attackPower += chosenCycle.gruntAttackAdd;
            }
            // Any other units will get spawn rate added based on scriptable object
            else 
            {
                enemyTypes[i].spawnRate += Random.Range(chosenCycle.othersSpawnAddRange.x, chosenCycle.othersSpawnAddRange.y);
            }
            // IF the enemy type is Assassin, speed will be added based on scriptable object
            if (enemyTypes[i].enemyClass == EnemyClass.Assassin) 
            {
                enemyTypes[i].speed += Random.Range(chosenCycle.assassinSpeedAddRange.x, chosenCycle.assassinSpeedAddRange.y);
            }
            // If it is below 0 because of negatives, make it 0 to avoid future problems (-0.1 chance is the same as 0 chance)
            if (enemyTypes[i].spawnRate < 0f) 
                enemyTypes[i].spawnRate = 0f;
        }

        for (int s = 0; s < spawners.Count; s++) // Triggers spawner script using the enemy types we just modified
        {
            spawners[s].Spawn(enemyTypes);
        }
    }
}