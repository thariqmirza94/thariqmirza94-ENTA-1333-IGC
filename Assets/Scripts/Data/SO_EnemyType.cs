using UnityEngine;

public enum EnemyClass
{
    Grunt, Archer, Assassin
}

[CreateAssetMenu(menuName = "Data/SO_EnemyType")]
public class SO_EnemyType : ScriptableObject
{
    [SerializeField] private EnemyClass enemyClassBase;
    [SerializeField] private int attackPowerBase;
    [SerializeField] private int healthBase;
    [SerializeField] private float speedBase;
    [SerializeField] private float spawnRateBase;
    
    [HideInInspector] public EnemyClass enemyClass;
    [HideInInspector] public int attackPower;
    [HideInInspector] public int health;
    [HideInInspector] public float speed;
    [HideInInspector] public float spawnRate;

    public void ResetRuntime()
    {
        enemyClass = enemyClassBase;
        attackPower = attackPowerBase;
        health = healthBase;
        speed = speedBase;
        spawnRate = spawnRateBase;
    }
}