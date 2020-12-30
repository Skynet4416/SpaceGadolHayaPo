using UnityEngine;

/// <summary>
/// Wait for user tap to start.
/// </summary>
[CreateAssetMenu(menuName = "Wave Parts/Tap To Start")]
public class TapToStart : StartWave {
    /// <returns>true if user tapped, false otherwise.</returns>
    public override bool IsFinished() {
        return Input.GetMouseButton(0) || Input.touchCount > 0;
    }
}
