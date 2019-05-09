using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Methods for interacting with buttons in main menu.
/// </summary>
public class TitleMenu : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName;
    [SerializeField]
    private GameObject creditsMenuPanel;
    [SerializeField]
    private GameObject titleMenuPanel;
    [Tooltip("Particle effect to play after clicking the start button.")]
    [SerializeField]
    private GameObject lightningExplosion;

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void StartExplosion()
    {
        lightningExplosion.SetActive(true);
    }

    public void ShowTitle()
    {
        titleMenuPanel.SetActive(true);
    }

    public void ShowCredits()
    {
        creditsMenuPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("Quit.");
        Application.Quit();
    }

    public void LinkTo(string link)
    {
        Application.OpenURL(link);
    }
}
