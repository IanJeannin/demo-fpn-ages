using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Specialized interactive object that is animated when interacted with.
/// </summary>
[RequireComponent(typeof(Animator))]
public class Door : InteractiveObjects
{
    [Tooltip("Check this box to lock the door.")]
    [SerializeField]
    private bool isLocked;

    [Tooltip("The text that displays when the player looks at the door while it's locked.")]
    [SerializeField]
    private string lockedDisplayText= "Locked.";
    [Tooltip("Play this audio clip when the player activates a locked door without a key.")]
    [SerializeField]
    private AudioClip lockedAudioClip;
    [Tooltip("Play this audio clip when the player activates an unlocked door.")]
    [SerializeField]
    private AudioClip openAudioClip;

    public override string DisplayText
    {
        get
        {
            if(isLocked)
            {
                return lockedDisplayText;
            }
            else
            {
                return base.displayText;
            }
        }
    }

    private Animator animator;
    private bool isOpen = false;
    private int shouldOpenAnimParameter=Animator.StringToHash("shouldOpen");
    /// <summary>
    /// Using a constructor here to initialize displayText in the editor
    /// </summary>
    public Door()
    {
        displayText = nameof(Door);
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    public override void InteractWith()
    {
        if(!isOpen)
        {
            if(!isLocked)
            {
            audioSource.clip = openAudioClip;
            animator.SetBool(shouldOpenAnimParameter, true);
            displayText = string.Empty;
            isOpen = true;
            }
            else //If the door is locked...
            {
                audioSource.clip = lockedAudioClip;
            }
            base.InteractWith(); //This plays a sound effect.
        }
    }
}
