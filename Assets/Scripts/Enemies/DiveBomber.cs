using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Kamikaze enemy, dive bomber, if you shall, creeper, if you'd like.
/// </summary>
public class DiveBomber : Entity {
    /// <summary>
    /// Attached rigidbody.
    /// </summary>
    private Rigidbody2D rb;
    /// <summary>
    /// Damage on contact.
    /// </summary>
    public float damage;

    /// <summary>
    /// On start, get attached rigidbody.
    /// </summary>
    private void Start() {
        this.rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// On update, move towards player.
    /// </summary>
    protected override void Update() {
        base.Update();

        this.Move();
    }

    /// <summary>
    /// Move towards player.
    /// </summary>
    private void Move() {
        Vector2 direction = (PlayerController.instance.transform.position - transform.position).normalized;
        transform.up = -direction;
        this.rb.velocity = -transform.up * this.moveSpeed;
    }

    /// <summary>
    /// On collision with player, explode and deal damage.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision) {
        PlayerController player = collision.collider.GetComponent<PlayerController>();
        if (player != null) {
            player.DealDamage(this.damage);
            this.Die();
        }
    }
}
