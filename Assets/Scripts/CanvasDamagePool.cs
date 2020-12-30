using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class used for pooling damage indicators.
/// </summary>
public class CanvasDamagePool : MonoBehaviour {
    /// <summary>
    /// Singleton instance.
    /// </summary>
    public static CanvasDamagePool instance;
    /// <summary>
    /// Damage indicator prefab.
    /// </summary>
    public DamageIndicator indicatorPrefab;
    /// <summary>
    /// Damage indicator pool.
    /// </summary>
    private Queue<DamageIndicator> pool;

    /// <summary>
    /// On start, initialize singleton and pool with 100 indicators.
    /// </summary>
    void Start() {
        if (CanvasDamagePool.instance == null) {
            CanvasDamagePool.instance = this;
        }
        else {
            Destroy(this.gameObject);
        }

        pool = new Queue<DamageIndicator>();
        for (int i = 0; i < 100; i++) {
            DamageIndicator indicator = Instantiate(indicatorPrefab, this.transform);
            indicator.gameObject.SetActive(false);
            this.pool.Enqueue(indicator);
        }
    }

    /// <summary>
    /// Enable and animate indicator according to parameters.
    /// </summary>
    /// <param name="position">Indicator position</param>
    /// <param name="damage">Damage to indicate</param>
    /// <param name="color">Indicator color</param>
    public void IndicateDamage(Vector2 position, float damage, Color color) {
        DamageIndicator indicator = this.pool.Dequeue();
        indicator.gameObject.SetActive(true);
        indicator.transform.position = Camera.main.WorldToScreenPoint(position);
        indicator.StartCoroutine(indicator.Popup(damage.ToString(), color));
        this.pool.Enqueue(indicator);
    }
}
