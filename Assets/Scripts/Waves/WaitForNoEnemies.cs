using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Waits until no enemies are left to continue to next wave part.
/// </summary>
[CreateAssetMenu(menuName = "Wave Parts/Wait for no Enemies")]
public class WaitForNoEnemies : WavePart {

    public override void Start() {

    }

    public override void Execute() {

    }

    /// <returns>true if all enemies are dead, false otherwise.</returns>
    public override bool IsFinished() {
        return WaveManager.instance.enemiesAlive <= 0;
    }
}
