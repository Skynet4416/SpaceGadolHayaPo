using System.Collections;
using UnityEngine;

/// <summary>
/// Generic bullet.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {
    /// <summary>
    /// Bullet speed.
    /// </summary>
    public float moveSpeed;
    /// <summary>
    /// Bullet direction.
    /// </summary>
    public Vector2 direction;

    /// <summary>
    /// Bullet damage.
    /// </summary>
    public float damage;

    /// <summary>
    /// Bullet life time.
    /// </summary>
    public float lifeTime;
    /// <summary>
    /// Timer used for life time.
    /// </summary>
    private float aliveTime;

    /// <summary>
    /// Attached rigidbody.
    /// </summary>
    protected Rigidbody2D rb;

    /// <summary>
    /// Get attached rigidbody and set velocity.
    /// </summary>
    void Start() {
        this.rb = GetComponent<Rigidbody2D>();
        this.rb.velocity = this.direction.normalized * this.moveSpeed;
    }

    /// <summary>
    /// Destroy bullet when it's time is up :).
    /// </summary>
    void Update() {
        this.aliveTime += Time.deltaTime;
        if (this.aliveTime >= this.lifeTime) {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Handle trigger enter (for derived classes).
    /// </summary>
    protected virtual void OnTriggerEnter2D(Collider2D collider) {
        return;
    }
}
