using UnityEngine;

[CreateAssetMenu(menuName = "Wave Parts/Debug Message")]
public class DebugWavePart : WavePart {
    public string message;

    public override void Start() {
        Debug.Log(this.message);
    }

    public override void Execute() {

    }

    public override bool IsFinished() {
        return true;
    }
}
