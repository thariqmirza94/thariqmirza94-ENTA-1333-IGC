using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/SO_DayCycle")]
public class SO_DayCycle : ScriptableObject
{
    public string cycleName;
    public bool blockAssassins;
    public Vector2 archerSpawnAddRange;
    public Vector2 brownSpawnAddRange;
    public int gruntAttackAdd;
    public Vector2 othersSpawnAddRange;
    public Vector2 assassinSpeedAddRange;
}
