using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script put on GameObjects that requires them to have necessary components, and prints out a message when object is interacted with.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class InteractiveObjects : MonoBehaviour, IInteractive
{
    [Tooltip("Text that will display in the UI when the player looks at the object in this world.")]
    [SerializeField]
    protected string displayText = nameof(InteractiveObjects);

    public virtual string DisplayText => displayText;
    protected AudioSource audioSource;

    /// <summary>
    /// Updates audioSource to the AudioSource of the object being interacted with.
    /// </summary>
    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// When user interacts with an object, plays the associated audio file and prints out a message.
    /// </summary>
    public virtual void InteractWith()
    {
        try
        {
            audioSource.Play();
        }
        catch (System.Exception)
        {

            throw new System.Exception("Interactive Object requires an audio source component with Audio Clip assigned -Is Missing-");
        }
        Debug.Log($"Player interacted with:  { gameObject.name}");
        if(gameObject.GetComponent<SpeechUpdate>()!=null)
        {
            gameObject.GetComponent<SpeechUpdate>().UpdateSpeechText();
        }
    }
    
}
