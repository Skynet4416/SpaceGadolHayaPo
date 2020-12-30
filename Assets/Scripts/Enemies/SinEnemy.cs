using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Shooting enemy that moves based on sin waves.
/// </summary>
public class SinEnemy : ShootingEnemy {
    /// <summary>
    /// Stored start position.
    /// </summary>
    private Vector2 startPosition;
    /// <summary>
    /// Store time for position calculation.
    /// </summary>
    private float aliveTime;

    /// <summary>
    /// Scale of x sin wave.
    /// </summary>
    public float xSinScale;
    /// <summary>
    /// Speed of x sin wave.
    /// </summary>
    public float xSinSpeed;

    /// <summary>
    /// Scale of y sin wave.
    /// </summary>
    public float ySinScale;
    /// <summary>
    /// Speed of y sin wave.
    /// </summary>
    public float ySinSpeed;

    /// <summary>
    /// On start, store position.
    /// </summary>
    void Start() {
        this.startPosition = this.transform.position;
    }

    /// <summary>
    /// On update, tick internal timer.
    /// </summary>
    protected override void Update() {
        base.Update();

        this.aliveTime += Time.deltaTime;
    }

    /// <summary>
    /// Move according to sin wave.
    /// </summary>
    protected override void Move() {
        this.transform.position = new Vector2(this.startPosition.x + CalculateOffset(this.xSinScale, this.xSinSpeed),
                                              this.startPosition.y + CalculateOffset(this.ySinScale, this.ySinSpeed));
    }

    /// <summary>
    /// Calculates sin wave offset.
    /// </summary>
    /// <param name="sinScale">Sin wave scale.</param>
    /// <param name="sinSpeed">Sin wave speed.</param>
    private float CalculateOffset(float sinScale, float sinSpeed) {
        return sinScale * Mathf.Sin(this.aliveTime * sinSpeed * this.moveSpeed);
    }
}
