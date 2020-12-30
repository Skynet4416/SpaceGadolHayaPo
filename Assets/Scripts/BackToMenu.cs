using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Used for going back to menu from the game.
/// </summary>
public class BackToMenu : MonoBehaviour {
    public void GoBackToMenu() {
        SceneManager.LoadScene(0);
    }
}
