/// <summary>
/// Generic constants class.
/// </summary>
public class Constants {
    /// <summary>
    /// Minimum distance where player follows the touch, prevents stuttering.
    /// </summary>
    public static readonly float CURSOR_FOLLOW_THRESHOLD = 0.01f;

    /// <summary>
    /// Player tag, used for collision detection.
    /// </summary>
    public static readonly string PLAYER_TAG = "Player";

    /// <summary>
    /// Default player fire rate.
    /// </summary>
    public static readonly float DEFAULT_FIRE_RATE = 10;

    /// <summary>
    /// Enemy tag, used for collision detection.
    /// </summary>
    public static readonly string ENEMY_TAG = "Enemy";

    /// <summary>
    /// Enemy collision layer name.
    /// </summary>
    public static readonly string ENEMY_LAYER = "Enemies";

    /// <summary>
    /// Minimum distance where enemy follows player, prevents stuttering.
    /// </summary>
    public static readonly float ENEMY_FOLLOW_THRESHOLD = 0.1f;

    /// <summary>
    /// Height of background, used for scrolling.
    /// </summary>
    public static readonly float BACKGROUND_HEIGHT = 4000 / 400;

    /// <summary>
    /// Chance of powerup on enemy death.
    /// </summary>
    public static readonly float POWERUP_CHANCE = 0.25f;

    /// <summary>
    /// Shoot SFX volume.
    /// </summary>
    public static readonly float SHOOT_SFX_VOLUME = 0.3f;
}
