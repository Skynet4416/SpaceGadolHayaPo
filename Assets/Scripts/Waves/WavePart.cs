using UnityEngine;

/// <summary>
/// Abstract wave part.
/// </summary>
public abstract class WavePart : ScriptableObject {
    /// <summary>
    /// Runs on wave part start.
    /// </summary>
    public abstract void Start();
    /// <summary>
    /// Runs every frame on wave part.
    /// </summary>
    public abstract void Execute();
    /// <summary>
    /// Tells the wave manager when to advance to the next part.
    /// </summary>
    public abstract bool IsFinished();
}
