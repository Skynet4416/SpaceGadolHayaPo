using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : ShootingEntity {
    /// <summary>
    /// Singleton instance.
    /// </summary>
    public static PlayerController instance;

    /// <summary>
    /// Attached rigidbody.
    /// </summary>
    private Rigidbody2D rb;
    /// <summary>
    /// Attached sprite renderer.
    /// </summary>
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// Target position to move to.
    /// </summary>
    private Vector3 targetPosition;

    /// <summary>
    /// Ammo left before switching to default bullet.
    /// </summary>
    public int currentAmmo;
    /// <summary>
    /// Current bullet being shot.
    /// </summary>
    public Bullet currentBullet;
    /// <summary>
    /// Is using the default bullet?
    /// </summary>
    public bool usingDefaultBullet;

    /// <summary>
    /// Length of invulnerability period.
    /// </summary>
    public float invulnerabilityPeriod;
    /// <summary>
    /// Is invulnerable?
    /// </summary>
    private bool invulnerable;

    /// <summary>
    /// UI HP indicator.
    /// </summary>
    public RectTransform hpIndicator;
    /// <summary>
    /// 1 HP to hp indicator width difference.
    /// </summary>
    private float hpToWidth;

    /// <summary>
    /// "You lose" menu to activate on death.
    /// </summary>
    public RectTransform loseMenu;

    /// <summary>
    /// Before start, initialize important properties.
    /// </summary>
    protected override void Awake() {
        base.Awake();

        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(this.gameObject);
        }

        this.tag = Constants.PLAYER_TAG;
        this.shootTimer = 0;
        this.usingDefaultBullet = true;
        this.currentBullet = this.defaultBullet;
        if (this.hpIndicator != null) {
            this.hpToWidth = hpIndicator.rect.width / this.maxHp;
        }
    }

    /// <summary>
    /// On start, get Rigidbody2D and set targetPosition to current position.
    /// </summary>
    void Start() {
        this.rb = GetComponent<Rigidbody2D>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.targetPosition = transform.position;
        this.invulnerable = false;
    }

    /// <summary>
    /// On Update, set/reset targetPosition and shoots based on shootTimer and fireRate.
    /// </summary>
    protected override void Update() {
        base.Update();

        if (Application.isMobilePlatform) {
            if (Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);
                this.shootTimer += Time.deltaTime;

                if (touch.phase == TouchPhase.Moved) {
                    SetTargetPosition(touch.position);
                }
            }
            else {
                ResetTargetPosition();
            }
        }
        else {
            if (Input.GetMouseButton(0)) {
                this.shootTimer += Time.deltaTime;
                SetTargetPosition(Input.mousePosition);
            }
            else {
                ResetTargetPosition();
            }
        }

        if (this.shootTimer >= 1 / this.fireRate) {
            this.shootTimer = 0;
            if (this.usingDefaultBullet || this.currentAmmo-- > 0) {
                Bullet bullet = Instantiate(currentBullet, this.firePoint.position, transform.rotation);
                MusicManager.instance.source.PlayOneShot(this.shootEffect, Constants.SHOOT_SFX_VOLUME);
            }
            else if (!this.usingDefaultBullet) {
                SetBullet(true, Constants.DEFAULT_FIRE_RATE, this.defaultBullet, 0);
            }
        }
    }

    /// <summary>
    /// Sets members based on parameters.
    /// </summary>
    /// <param name="defaultBullet">Are you using the default bullet</param>
    /// <param name="fireRate">How many bullets fired per second?</param>
    /// <param name="bullet">Bullet prefab.</param>
    /// <param name="ammoCount">Ammo count before resetting back to default bullet.</param>
    public void SetBullet(bool defaultBullet, float fireRate, Bullet bullet, int ammoCount) {
        this.usingDefaultBullet = defaultBullet;
        this.fireRate = fireRate;
        this.currentBullet = bullet;
        this.currentAmmo = ammoCount;
    }

    /// <summary>
    /// Deals damage or head and activates invulnerability frames.
    /// </summary>
    /// <param name="damage">Amount of damage to deal.</param>
    /// <returns>true if damage was dealt, false otherwise.</returns>
    public override bool DealDamage(float damage) {
        if (!invulnerable || damage <= 0) {
            base.DealDamage(damage);

            if (this.hpIndicator != null) {
                Vector2 upperRight = this.hpIndicator.offsetMax;
                upperRight.x = -this.hpToWidth * (this.maxHp - this.hp);
                this.hpIndicator.offsetMax = upperRight;
            }

            if (damage > 0) {
                StartCoroutine(BeInvulnerable());
            }
            return true;
        }

        return false;
    }

    /// <summary>
    /// Invulnerability handler coroutine.
    /// </summary>
    IEnumerator BeInvulnerable() {
        this.invulnerable = true;
        Color color = this.spriteRenderer.color;
        int blinkCount = 20;

        for (int blink = 0; blink < blinkCount; blink++) {
            color.a = 0.3f * (blink % 2) + 0.3f;
            this.spriteRenderer.color = color;
            yield return new WaitForSeconds(invulnerabilityPeriod / blinkCount);
        }

        color.a = 1;
        this.spriteRenderer.color = color;
        this.invulnerable = false;
    }

    /// <summary>
    /// Activates losing menu.
    /// </summary>
    protected override void Die() {
        loseMenu.gameObject.SetActive(true);
        Instantiate(particlePrefab, transform.position, Quaternion.Euler(-90, 0, 0));
        Destroy(this.gameObject);
    }

    /// <summary>
    ///  Set targetPosition from mouse/touch position.
    /// </summary>
    /// <param name="touchPosition">Mouse/Touch position.</param>
    void SetTargetPosition(Vector3 touchPosition) {
        this.targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.targetPosition.y -= 0.35f;
        this.targetPosition.z = 0;
    }

    /// <summary>
    ///  Reset targetPosition to current position.
    /// </summary>
    void ResetTargetPosition() {
        this.targetPosition = transform.position;
    }

    /// <summary>
    /// On "fixed update" (framerate independent), head towards targetPosition if too far away.
    /// </summary>
    void FixedUpdate() {
        Vector3 targetDirection = this.targetPosition - transform.position;

        if (targetDirection.sqrMagnitude > 0.01f) {
            this.rb.velocity = targetDirection.normalized * this.moveSpeed;
        }
        else {
            this.rb.velocity = Vector3.zero;
        }
    }
}
