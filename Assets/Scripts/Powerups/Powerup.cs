using UnityEngine;

/// <summary>
/// Generic power up.
/// Extends bullet for movement and life time logic.
/// </summary>
public abstract class Powerup : Bullet {

    /// <summary>
    /// Call AcquirePowerup and destroy gameObject of collision with player.
    /// </summary>
    protected override void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag(Constants.PLAYER_TAG)) {
            this.AcquirePowerup();
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Abstract power up for derived classes.
    /// </summary>
    protected abstract void AcquirePowerup();
}
