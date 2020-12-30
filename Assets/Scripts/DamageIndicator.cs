using System.Collections;
using UnityEngine;
using TMPro;

/// <summary>
/// Simple aninmated damage indicator.
/// </summary>
public class DamageIndicator : MonoBehaviour {
    /// <summary>
    /// Attached text mesh.
    /// </summary>
    public TextMeshProUGUI textMesh;

    /// <summary>
    /// Vertical speed.
    /// </summary>
    public float ySpeed;
    /// <summary>
    /// Max font size.
    /// </summary>
    public float fontSize;

    /// <summary>
    /// How long to grow text for.
    /// </summary>
    public float sizeTime;
    /// <summary>
    /// How long to fade in for.
    /// </summary>
    public float fadeTime;

    /// <summary>
    /// On enable, get attached text mesh.
    /// </summary>
    void OnEnable() {
        this.textMesh = GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// Animate vertical movement.
    /// </summary>
    void Update() {
        transform.position += new Vector3(0, ySpeed * Time.deltaTime, 0);
    }

    /// <summary>
    /// Animate font size and alpha value.
    /// </summary>
    /// <param name="text">Text to display</param>
    /// <param name="color">Color of text</param>
    /// <returns></returns>
    public IEnumerator Popup(string text, Color color) {
        this.textMesh.fontSize = 0;
        this.textMesh.alpha = 1;
        this.textMesh.text = text;
        this.textMesh.color = color;
        while (this.textMesh.fontSize < this.fontSize) {
            this.textMesh.fontSize += fontSize / (sizeTime * 10);
            yield return new WaitForSeconds(0.1f);
        }

        while (this.textMesh.alpha > 0) {
            this.textMesh.alpha -= 1 / (fadeTime * 10);
            yield return new WaitForSeconds(0.1f);
        }

        this.gameObject.SetActive(false);
    }
}
