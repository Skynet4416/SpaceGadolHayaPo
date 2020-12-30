using UnityEngine;

public class Powerupper : MonoBehaviour {
    public static Powerupper instance;
    public Powerup[] possiblePowerups;

    void Start() {
        if (Powerupper.instance == null) {
            Powerupper.instance = this;
        }
        else {
            Destroy(this.gameObject);
        }
    }

    public Powerup RandomPowerup() {
        return possiblePowerups[Random.Range(0, possiblePowerups.Length)];
    }
}
