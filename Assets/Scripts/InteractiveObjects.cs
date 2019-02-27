using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjects : MonoBehaviour, IInteractive
{
    public void InteractWith()
    {
        Debug.Log($"Player interacted with:  { gameObject.name}");
    }
}
