using System;
using UnityEngine;

/// <summary>
/// Enemy summon representation for waves.
/// </summary>
[Serializable]
public class EnemyToSummon {
    /// <summary>
    /// Enemy prefab.
    /// </summary>
    public GameObject prefab;
    /// <summary>
    /// Summon position.
    /// </summary>
    public Vector3 position;
}
