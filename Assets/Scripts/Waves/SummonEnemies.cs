using UnityEngine;

/// <summary>
/// Summons enemies.
/// </summary>
[CreateAssetMenu(menuName = "Wave Parts/Summon Enemies")]
public class SummonEnemies : WavePart {
    /// <summary>
    /// Enemies to summon.
    /// </summary>
    public EnemyToSummon[] enemies;

    /// <summary>
    /// On start, summon the enemies.
    /// </summary>
    public override void Start() {
        WaveManager.instance.enemiesAlive += enemies.Length;

        for (int i = 0; i < enemies.Length; i++) {
            WaveManager.Instantiate(enemies[i].prefab, enemies[i].position, Quaternion.identity);
        }
    }

    public override void Execute() { }

    /// <summary>
    /// Immediately done.
    /// </summary>
    public override bool IsFinished() {
        return true;
    }
}
