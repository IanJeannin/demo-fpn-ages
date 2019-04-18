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
    [SerializeField]
    private TextMeshProUGUI textMeshPro;
    [SerializeField]
    private int secondsBeforeSpeechFades;

    private bool startFading = false;
    
    private void Start()
    {
        textMeshPro.alpha = 0;
    }
    protected void UpdateText(string triggerText)
    {
        textMeshPro.SetText(triggerText);
        textMeshPro.alpha = 1;
        StartCoroutine(SpeechFadeOut());
    }

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

    private void Update()
    {
        if(startFading==true)
        {
            FadeOut();
        }
    }
}