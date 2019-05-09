using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This UI Text displays speech when the player crosses invisible triggers.
/// The text should be hidden after a short time.
/// </summary>
public class SpeechDisplayText : MonoBehaviour
{
    [Tooltip("The TextMeshPro text component that needs to be changed.")]
    [SerializeField]
    private TextMeshProUGUI textMeshPro;
    [Tooltip("How long before the speech text will begin to fade out.")]
    [SerializeField]
    private int secondsBeforeSpeechFades=2;

    private bool startFading = false;
    
    private void Start()
    {
        //Ensure no speech is displayed on start of game. 
        textMeshPro.alpha = 0;
    }
    protected void UpdateText(string triggerText)
    {
        startFading = false; //Ensures speech doesn't begin fading immediately if two triggers are triggered in quick succession.
        textMeshPro.SetText(triggerText); //Set UI text to the text of the trigger. 
        textMeshPro.alpha = 1; //Make text appear. 
        StartCoroutine(SpeechFadeOut());
    }

    /// <summary>
    /// Method called after coroutine ends, fades out text for as long as the text's alpha is not 0. 
    /// </summary>
    private void FadeOut()
    {
        if (textMeshPro.alpha > 0)
        {
            float firstAlpha = 1;
            float textAlpha = textMeshPro.alpha;
            textMeshPro.alpha = textAlpha - firstAlpha * 0.01f;
        }
        else
        {
            startFading = false;
        }
    }

    private IEnumerator SpeechFadeOut()
    {
        yield return new WaitForSeconds(secondsBeforeSpeechFades);
        startFading = true;
    }

    private void FixedUpdate()
    {
        if(startFading==true)
        {
            FadeOut();
        }
        Debug.Log(startFading);
    }
}