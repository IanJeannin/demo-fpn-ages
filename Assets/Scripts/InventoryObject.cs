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

    [Tooltip("The text that will display when the player selects this object in the inventory menu.")]
    [TextArea(3,8)]
    [SerializeField]
    private string description;

    [Tooltip("Icon to display for this item in the inventory menu.")]
    [SerializeField]
    private Sprite icon;

    public Sprite Icon => icon;
    public string Description => description;
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
        InventoryMenu.Instance.AddItemToMenu(this);
        renderer.enabled = false;
        foreach(Transform child in this.transform)
        {
            child.gameObject.SetActive(false);
        }
        collider.enabled = false;
        Debug.Log($"Inventory menu game object name {InventoryMenu.Instance.name}");
    }
}
