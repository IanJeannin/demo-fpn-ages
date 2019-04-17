using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuItemToggle : MonoBehaviour
{
    [Tooltip("The image component used to show the associated object's icon.")]
    [SerializeField]
    private Image iconImage;

    public static event Action<InventoryObject> InventoryMenuItemSelected;
    private InventoryObject associatedInventoryObject;

    public InventoryObject AssociatedInventoryObject
    {
        get
        {
            return associatedInventoryObject;
        }
        set
        {
            associatedInventoryObject = value;
            iconImage.sprite = associatedInventoryObject.Icon;
        }
    }

    /// <summary>
    /// This will be plugged into the toggles OnValueChanged property in editor
    /// Called whenever the toggle is clicked.
    /// </summary>
    public void InventoryMenuItemWasToggled(bool isOn)
    {
        //We only want to do the stuff when the toggle has been selected, not when deselected
        if(isOn)
        {
            InventoryMenuItemSelected?.Invoke(AssociatedInventoryObject);
        }
        Debug.Log(isOn);
    }

    private void Awake()
    {
        Toggle toggle = GetComponent<Toggle>();
        ToggleGroup toggleGroup = GetComponentInParent<ToggleGroup>();
        toggle.group = toggleGroup;
    }
}
