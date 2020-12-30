using UnityEngine;

/// <summary>
/// Area of Effect Bullet, used for rocket bullets.
/// </summary>
public class AoEBullet : SimpleBullet {
    /// <summary>
    /// Explosion radius.
    /// </summary>
    public float radius;
    /// <summary>
    /// Explosion particle effect.
    /// </summary>
    public ParticleSystem rocketExplosion;

    /// <summary>
    /// On trigger enter, explode and damage everyone in explosion radius.
    /// </summary>
    protected override void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag(this.collisionTag)) {
            Collider2D[] inArea = Physics2D.OverlapCircleAll(transform.position, this.radius);

            for (int i = 0; i < inArea.Length; i++) {
                Entity entity = inArea[i].GetComponent<Entity>();
                if (entity != null && collider.CompareTag(this.collisionTag)) {
                    entity.DealDamage(this.damage);
                    Vector3 indicatorOffset = new Vector3(Random.Range(-0.2f, 0.2f), 1, 0);
                    CanvasDamagePool.instance.IndicateDamage(entity.transform.position + indicatorOffset, this.damage, Color.red);
                }
            }

            Instantiate(rocketExplosion, this.transform.position, Quaternion.Euler(-90, 0, 0));
            Destroy(this.gameObject);
        }
    }
}
