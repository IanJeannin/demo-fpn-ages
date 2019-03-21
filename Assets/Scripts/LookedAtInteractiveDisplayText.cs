using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This UI Text displays info about the current looked at IInteractive Element.
/// The text should be hidden if player is not looking at an interactive.
/// </summary>
public class LookedAtInteractiveDisplayText : MonoBehaviour
{
    private IInteractive lookedAtInteractive;
    private Text displayText;

    /// <summary>
    /// Initializes text at start of program.
    /// </summary>
    private void Awake()
    {
        displayText = GetComponent<Text>();
        UpdateDisplayText();
    }

    /// <summary>
    /// If player is looking at an interactive object, show the display text, otherwise, hide it.
    /// </summary>
    private void UpdateDisplayText()
    {
        if (lookedAtInteractive != null)
        {
            displayText.text = lookedAtInteractive.DisplayText;
        }
        else
        {
            displayText.text = string.Empty;
        }
    }

    /// <summary>
    /// Event handler for DetectLookedAtInteractive.LookedAtInteractiveChanged
    /// </summary>
    /// <param name="newLookedAtInteractive">Reference to the new IInteractive the player is looking at</param>
    private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive)
    {
        lookedAtInteractive = newLookedAtInteractive;
        UpdateDisplayText();
    }

    #region Event subscription / unsubscription
    private void OnEnable()
    {
        DetectLookedAtInteractive.LookedAtInteractiveChanged += OnLookedAtInteractiveChanged;
    }

    private void OnDisable()
    {
        DetectLookedAtInteractive.LookedAtInteractiveChanged -= OnLookedAtInteractiveChanged;
    }
    #endregion
}
