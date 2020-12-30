using UnityEngine;

/// <summary>
/// Waits before starting next wave part.
/// </summary>
[CreateAssetMenu(menuName = "Wave Parts/Delay")]
public class WaveDelay : WavePart {
    /// <summary>
    /// How long to wait.
    /// </summary>
    public float delayLength;
    /// <summary>
    /// Internal timer for waiting.
    /// </summary>
    private float timer;

    /// <summary>
    /// On start, set timer to 0.
    /// </summary>
    public override void Start() {
        this.timer = 0;
    }

    /// <summary>
    /// Tick internal timer.
    /// </summary>
    public override void Execute() {
        this.timer += Time.deltaTime;
    }

    /// <returns>true when timer reaches delayLength, false otherwise.</returns>
    public override bool IsFinished() {
        return this.timer >= this.delayLength;
    }
}
