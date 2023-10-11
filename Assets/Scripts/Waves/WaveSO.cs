using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave Generation", menuName = "ScriptableObjects/Waves")]
public class WaveSO : ScriptableObject
{
    public int enemiesToSpawn;
    public float spawnDelay;
    public float enemySpeed;
    public GameObject enemy;
    public int timeUntilSpawn;
}
