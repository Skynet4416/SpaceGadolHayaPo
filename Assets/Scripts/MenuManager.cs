using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Responsible for main menu functions.
/// </summary>
public class MenuManager : MonoBehaviour {
    /// <summary>
    /// Main menu container object.
    /// </summary>
    public GameObject menu;
    /// <summary>
    /// Story container object.
    /// </summary>
    public GameObject story;

    /// <summary>
    /// Loads the main game scene.
    /// </summary>
    public void StartGame() {
        SceneManager.LoadScene(1);
    }
    
    /// <summary>
    /// Quits game.
    /// </summary>
    public void QuitGame() {
        Application.Quit();
    }

    /// <summary>
    /// Hides menu, shows story.
    /// </summary>
    public void ShowStory() {
        this.menu.SetActive(false);
        this.story.SetActive(true);
    }

    /// <summary>
    /// Hides story, shows menu.
    /// </summary>
    public void HideStory() {
        this.story.SetActive(false);
        this.menu.SetActive(true);
    }
}