/// <summary>
/// Power up that sets new bullet type.
/// </summary>
public class BulletPowerup : Powerup {
    public float fireRate;
    public Bullet bulletPrefab;
    public int ammoCount;

    protected override void AcquirePowerup() {
        PlayerController.instance.SetBullet(false, this.fireRate, this.bulletPrefab, this.ammoCount);
    }
}
