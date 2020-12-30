using UnityEngine;

/// <summary>
/// Simple bullet.
/// </summary>
public class SimpleBullet : Bullet {
    /// <summary>
    /// Which tag to collide with?
    /// </summary>
    public string collisionTag;

    /// <summary>
    /// Damage on collision.
    /// </summary>
    protected override void OnTriggerEnter2D(Collider2D collider) {
        Entity entity = collider.GetComponent<Entity>();
        if (entity != null && collider.CompareTag(this.collisionTag)) {
            if (entity.DealDamage(this.damage)) {
                Vector3 indicatorOffset = new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), 0);
                CanvasDamagePool.instance.IndicateDamage(transform.position + indicatorOffset, this.damage, Color.white);
            }
            Destroy(this.gameObject);
        }
    }
}
