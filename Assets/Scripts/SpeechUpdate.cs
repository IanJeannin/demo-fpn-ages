using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This UI Text displays speech when the player crosses invisible triggers.
/// The text should be hidden after a short time.
/// </summary>
public class SpeechUpdate : SpeechDisplayText
{
    /// <summary>
    /// The text that will play when the player crosses a trigger.
    /// </summary>
    [SerializeField]
    private string speechText;

    private bool hasBeenActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if(!hasBeenActivated)
        {
            UpdateSpeechText();
            hasBeenActivated = true;
        }
    }

    public void UpdateSpeechText()
    {
        UpdateText(speechText);
    }
}
