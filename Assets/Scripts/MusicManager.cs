using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles Music and SFX.
/// </summary>
public class MusicManager : MonoBehaviour {
    /// <summary>
    /// Singleton instance.
    /// </summary>
    public static MusicManager instance;
    /// <summary>
    /// Attached AudioSource.
    /// </summary>
    public AudioSource source;

    /// <summary>
    /// On start, initialize singleton and get attached AudioSource.
    /// </summary>
    void Start() {
        if (MusicManager.instance == null) {
            MusicManager.instance = this;
        }
        else {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        this.source = GetComponent<AudioSource>();
    }
}
