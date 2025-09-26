using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyClass // The three enemy classes that it can be
{
    Grunt, Archer, Assassin
}

[CreateAssetMenu(menuName="Data/SO_EnemyType")]
public class SO_EnemyType : ScriptableObject // Uses the previous enum for class, and the rest of the required attributes
{
    public EnemyClass enemyClass;
    public int attackPower;
    public int health;
    public float speed;
    public float spawnRate;
}