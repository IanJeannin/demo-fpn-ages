using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCutscene : MonoBehaviour
{ 
    [Tooltip("The panel that will be enabled to make the screen go black.")]
    [SerializeField]
    private GameObject fadeToBlackPanel;
    [Tooltip("How many seconds to wait after cutscene ends to take player back to home screen.")]
    [SerializeField]
    private float secondsTillGameEnd;

    private Animator animator;
    private int shouldStartAnimParameter = Animator.StringToHash("playerEnteredTunnel");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    public void TransitionToCutScene()
    {
        animator.enabled = true;
        animator.SetBool(shouldStartAnimParameter, true);
    }

    /// <summary>
    /// Called at end of cutscene animation. Will make screen go black, and shortly afterward end the game. 
    /// </summary>
    public void EndCutScene()
    {
        StartCoroutine(EndGame());
        fadeToBlackPanel.SetActive(true);
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(secondsTillGameEnd);
        Application.Quit();
    }
}
