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

    //private void Awake()
    //{
    //    textMeshPro = GetComponent<TextMeshProUGUI>();
    //}
    private void Start()
    {
        Debug.Log(textMeshPro.name);
    }
    protected void UpdateText(string triggerText)
    {
        textMeshPro.SetText(triggerText);
    }
}