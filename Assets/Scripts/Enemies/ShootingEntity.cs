using UnityEngine;

public class ShootingEntity : Entity {
    /// <summary>
    /// Default bullet shot.
    /// </summary>
    public Bullet defaultBullet;

    /// <summary>
    /// Bullets shot per second.
    /// </summary>
    [Min(0.1f)]
    public float fireRate;
    /// <summary>
    /// Timer used for shooting.
    /// </summary>
    protected float shootTimer;

    /// <summary>
    /// Where bullets are shot from.
    /// </summary>
    public Transform firePoint;

    /// <summary>
    /// Shooting SFX clip.
    /// </summary>
    public AudioClip shootEffect;
}