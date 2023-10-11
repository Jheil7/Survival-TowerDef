using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Object", menuName = "ScriptableObjects/Enemies")]
public class EnemyScriptableObject : ScriptableObject
{
    public string enemyName;
    public float enemyHealth;
    public float enemySpeed;
}
