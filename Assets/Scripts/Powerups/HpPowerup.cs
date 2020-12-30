/// <summary>
/// Health potion power up.
/// </summary>
public class HpPowerup : Powerup {
    /// <summary>
    /// On collision, heal player.
    /// </summary>
    protected override void AcquirePowerup() {
        PlayerController.instance.DealDamage(-this.damage);
    }
}
