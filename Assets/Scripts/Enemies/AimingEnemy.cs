using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy that moves in front of player and shoots.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class AimingEnemy : ShootingEnemy {
    /// <summary>
    /// Attached rigidbody.
    /// </summary>
    private Rigidbody2D rb;

    /// <summary>
    /// On start, get attached rigidbody.
    /// </summary>
    void Start() {
        this.rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Move in front of player.
    /// </summary>
    protected override void Move() {
        float distance = PlayerController.instance.transform.position.x - this.transform.position.x;

        if (Mathf.Abs(distance) > Constants.ENEMY_FOLLOW_THRESHOLD) {
            this.rb.velocity = new Vector2(Mathf.Sign(distance) * this.moveSpeed, 0);
        }
        else {
            this.rb.velocity = Vector2.zero;
        }
    }
}
