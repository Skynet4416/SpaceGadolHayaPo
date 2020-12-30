using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Manages the waves!
/// </summary>
public class WaveManager : MonoBehaviour {
    /// <summary>
    /// Singleton instance.
    /// </summary>
    public static WaveManager instance;

    /// <summary>
    /// Wave part array.
    /// </summary>
    public WavePart[] parts;
    /// <summary>
    /// Wave part queue.
    /// </summary>
    private Queue<WavePart> partQueue;
    /// <summary>
    /// Current wave part.
    /// </summary>
    private WavePart currentPart;

    /// <summary>
    /// Number of enemies alive.
    /// </summary>
    public int enemiesAlive;

    /// <summary>
    /// UI wave indicator.
    /// </summary>
    public TextMeshProUGUI waveIndicator;
    /// <summary>
    /// UI win menu.
    /// </summary>
    public RectTransform winMenu;

    /// <summary>
    /// On start, reset enemy count, initialize singleton and wave part queue.
    /// </summary>
    void Start() {
        this.enemiesAlive = 0;

        if (WaveManager.instance == null) {
            WaveManager.instance = this;
        }
        else {
            Destroy(this.gameObject);
        }

        this.partQueue = new Queue<WavePart>(this.parts);
    }

    /// <summary>
    /// Advance and execute wave parts, when none are left, enable win menu.
    /// </summary>
    void Update() {
        if (currentPart == null || currentPart.IsFinished()) {
            if (partQueue.Count == 0) {
                this.winMenu.gameObject.SetActive(true);
                PlayerController.instance.moveSpeed = 0;
            }
            else {
                this.currentPart = partQueue.Dequeue();
                this.currentPart.Start();
            }
        }

        this.currentPart.Execute();
    }
}
