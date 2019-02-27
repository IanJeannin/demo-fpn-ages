using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjects : MonoBehaviour, IInteractive
{
    [SerializeField]
    private string displayText = nameof(InteractiveObjects);

    public string DisplayText => displayText;

    public void InteractWith()
    {
        Debug.Log($"Player interacted with:  { gameObject.name}");
    }
}
