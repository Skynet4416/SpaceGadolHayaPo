using UnityEngine;

/// <summary>
/// Generic shooting enemy.
/// </summary>
public class ShootingEnemy : ShootingEntity {
    /// <summary>
    /// Tick internal timer and shoot when necessary.
    /// </summary>
    protected override void Update() {
        base.Update();

        this.Move();

        this.shootTimer += Time.deltaTime;
        if (this.shootTimer >= 1 / this.fireRate) {
            this.shootTimer = 0;
            this.Shoot();
        }
    }

    /// <summary>
    /// Unused move method, for derived classes.
    /// </summary>
    protected virtual void Move() {
        return;
    }

    /// <summary>
    /// To shoot, instantiate bullet and play SFX.
    /// </summary>
    protected virtual void Shoot() {
        Bullet bullet = Instantiate(this.defaultBullet, this.firePoint.position, transform.rotation);
        MusicManager.instance.source.PlayOneShot(this.shootEffect, Constants.SHOOT_SFX_VOLUME);
    }
}
