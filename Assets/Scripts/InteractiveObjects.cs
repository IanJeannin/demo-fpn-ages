using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InteractiveObjects : MonoBehaviour, IInteractive
{
    [SerializeField]
    protected string displayText = nameof(InteractiveObjects);

   
    public string DisplayText => displayText;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void InteractWith()
    {
        try
        {
            audioSource.Play();
        }
        catch (System.Exception)
        {

            throw new System.Exception("Interactive Object requires an audio source component -Is Missing-");
        }
        
        Debug.Log($"Player interacted with:  { gameObject.name}");
    }
}
