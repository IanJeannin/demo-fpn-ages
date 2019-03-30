using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObjects
{
    //TODO: Add long description field
    //TODO: Add icon field

    [Tooltip("The name of the object as it will appear in the inventory Menu UI.")]
    [SerializeField]
    private string objectName = nameof(InventoryObject);

    public string ObjectName => objectName;

    private new Renderer renderer;
    private new Collider collider;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }

    public InventoryObject()
    {
        displayText = $"Take {objectName}";
    }
   
    /// <summary>
    /// When the player interacts with a inventory object, we need to do two things:
    /// 1) Add the inventory object to the PlayerInventory list.
    /// 2) Remove the object from the game world.
    /// </summary>
    public override void InteractWith()
    {
        base.InteractWith();
        PlayerInventory.InventoryObjects.Add(this);
        renderer.enabled = false;
        collider.enabled = false;
    }
}
