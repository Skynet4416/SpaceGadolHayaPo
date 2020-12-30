using UnityEngine;

/// <summary>
/// Changes wave indicator and waits.
/// </summary>
[CreateAssetMenu(menuName = "Wave Parts/Start")]
public class StartWave : WaveDelay {
    public string waveText;

    /// <summary>
    /// On start, nable wave indicator.
    /// </summary>
    public override void Start() {
        base.Start();
        WaveManager.instance.waveIndicator.alpha = 1;
        WaveManager.instance.waveIndicator.text = waveText;
    }

    /// <summary>
    /// If finished, disable wave indicator.
    /// </summary>
    public override void Execute() {
        base.Execute();
        if (this.IsFinished()) {
            WaveManager.instance.waveIndicator.alpha = 0;
        }
    }
}
