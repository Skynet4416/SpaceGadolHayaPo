using UnityEngine;

/// <summary>
/// Common entity, used for anything with hp.
/// </summary>
public class Entity : MonoBehaviour {
    /// <summary>
    /// Max health.
    /// </summary>
    public float maxHp;
    /// <summary>
    /// Current health.
    /// </summary>
    public float hp;
    /// <summary>
    /// Move speed lol.
    /// </summary>
    public float moveSpeed;
    /// <summary>
    /// Particles to spawn on death.
    /// </summary>
    public ParticleSystem particlePrefab;

    /// <summary>
    /// On Awake, set hp to maxHp.
    /// </summary>
    protected virtual void Awake() {
        this.hp = this.maxHp;
    }

    /// <summary>
    /// Reduces hp by damage
    /// </summary>
    /// <param name="damage">How much to reduce hp by.</param>
    public virtual bool DealDamage(float damage) {
        this.hp = Mathf.Min(this.hp - damage, this.maxHp);
        return true;
    }

    /// <summary>
    /// Call Die when hp is 0.
    /// </summary>
    protected virtual void Update() {
        if (this.hp <= 0) {
            Die();
        }
    }

    /// <summary>
    /// Handle enemy death.
    /// </summary>
    protected virtual void Die() {
        WaveManager.instance.enemiesAlive--;
        Instantiate(particlePrefab, transform.position, Quaternion.Euler(-90, 0, 0));
        if (Random.value <= Constants.POWERUP_CHANCE) {
            Instantiate(Powerupper.instance.RandomPowerup(), transform.position, Quaternion.identity);
        }
        Destroy(this.gameObject);
    }
}
