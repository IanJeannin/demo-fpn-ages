using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Specialized interactive object that is animated when interacted with.
/// </summary>
[RequireComponent(typeof(Animator))]
public class Door : InteractiveObjects
{
    [Tooltip("Assigning a key here will lock the door, if the player has the key in their inventory they can open the locked door.")]
    [SerializeField]
    private InventoryObject key;
    [Tooltip("If this is checked, the associated key will be removed from the players inventory once it is used.")]
    [SerializeField]
    private bool consumesKey;
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
            string toReturn;

            if(isLocked)
            {
                toReturn = HasKey ? $"Use: {key.ObjectName}" : lockedDisplayText;
            }
            else
            {
                toReturn = base.displayText;
            }
            return toReturn;
        }
    }

    private bool HasKey => PlayerInventory.InventoryObjects.Contains(key);
    private Animator animator;
    private bool isOpen = false;
    private bool isLocked;
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
        InitializeIsLocked();
    }

    private void InitializeIsLocked()
    {
        if (key != null)
        {
            isLocked = true;
        }
    }

    public override void InteractWith()
    {
        if(!isOpen)
        {
            if(isLocked&&!HasKey)
            {
                audioSource.clip = lockedAudioClip;
            }
            else //If it's not locked or if it's locked and player does not have a key.
            {
                audioSource.clip = openAudioClip;
                animator.SetBool(shouldOpenAnimParameter, true);
                displayText = string.Empty;
                isOpen = true;
                UnlockDoor();
            }
            base.InteractWith(); //This plays a sound effect.
        }
    }

    private void UnlockDoor()
    {
        isLocked = false;
        if (key != null && consumesKey)
        {
            PlayerInventory.InventoryObjects.Remove(key);
        }
    }
}
